import pandas as pd
import mysql
import warnings
import numpy as np
import datetime

warnings.filterwarnings("ignore")


# 计算分系统等级 result_mid --grade
def check_grade_Mid(df):
    if ((df.score.astype(float) <= df['Mid_I_Top'].astype(float)).all() & (
            df.score.astype(float) >= df['Mid_I_Bottom'].astype(float)).all()):
        return 1
    if ((df.score.astype(float) < df['Mid_I_Bottom'].astype(float)).all() & (
            df.score.astype(float) >= df['Mid_II_Bottom'].astype(float)).all()):
        return 2
    if ((df.score.astype(float) < df['Mid_II_Bottom'].astype(float)).all() & (
            df.score.astype(float) >= df['Mid_III_Bottom'].astype(float)).all()):
        return 3
    if ((df.score.astype(float) < df['Mid_III_Bottom'].astype(float)).all() & (
            df.score.astype(float) >= df['Mid_IV_Bottom'].astype(float)).all()):
        return 4
    if ((df.score.astype(float) < df['Mid_IV_Bottom'].astype(float)).all() & (
            df.score.astype(float) >= df['Mid_V_Bottom'].astype(float)).all()):
        return 5


# 机电系统技术状况评定  同上
def check_grade_MES(df):
    if (float(df.score) <= float(df.MES_I_Top)) & (float(df.score) >= float(df.MES_I_Bottom)):
        return 1
    if (float(df.score) < float(df.MES_I_Bottom)) & (float(df.score) >= float(df.MES_II_Bottom)):
        return 2
    if (float(df.score) < float(df.MES_II_Bottom)) & (float(df.score) >= float(df.MES_III_Bottom)):
        return 3
    if (float(df.score) < float(df.MES_III_Bottom)) & (float(df.score) >= float(df.MES_IV_Bottom)):
        return 4
    if (float(df.score) < float(df.MES_IV_Bottom)) & (float(df.score) >= float(df.MES_V_Bottom)):
        return 5


# 计算设备级结果（设施清单，运营时间，失败时间，设备重要度）
def calEquipment(eq, eqo, eqf, imp):
    op = eqo[['Equipment_Code', 'working_time']].copy()
    fail = eqf[['Equipment_Code', 'failure_time']].copy()
    eplist = eq[['typeCode_Equipment', 'Equipment_Code']].copy()
    eqimp = imp[['typeName_Equipment', 'typeCode_Equipment', 'importance_Equipment']].copy()
    epOperation = pd.merge(eplist, op, how='left', on='Equipment_Code')
    epOperation.dropna(subset=['working_time'], inplace=True)
    epOperationFail = pd.merge(epOperation, fail, how='left', on='Equipment_Code')  # 拼接
    epOperationFail['failure_time'].fillna(0, inplace=True)  # 填充空值
    epOperationFail['typeCode_Equipment'] = epOperationFail['Equipment_Code'].str[12:18]
    eqRe = epOperationFail.groupby(['typeCode_Equipment'])['working_time', 'failure_time'].sum()
    eqRe.reset_index(inplace=True)
    eqRe['integrityrate_Equipment'] = (1 - eqRe['failure_time'] / eqRe['working_time']) * 100
    # eqRe.rename(columns={'equipment_type_code': 'equipment_code'}, inplace=True)
    # eqimp['equipment_code'] = eqimp['equipment_type_code'].str[-3:]
    eqResult = pd.merge(eqRe, eqimp, how='left', on='typeCode_Equipment')
    eqResult.dropna(subset=['importance_Equipment'], inplace=True)
    eqResult = eqResult[['typeCode_Equipment', 'typeName_Equipment', 'importance_Equipment', 'integrityrate_Equipment']]
    return eqResult


# 计算子系统级结果 （设备级结果，权重表）
def calSubsysetm(eqResult, weight):
    re = eqResult.copy()
    weight=weight[weight['LevelName']=='机电子系统']
    re['CODE'] = re['typeCode_Equipment'].str[:3]
    subre = re.groupby(['CODE'])['integrityrate_Equipment'].mean()
    subre = subre.reset_index()
    subre.rename(columns={'integrityrate_Equipment': 'integrityrate_Subsystem'}, inplace=True)
    system = re['CODE'].unique()
    # 计算A类设备分数
    A = {}
    for i in system:
        temp = re[(re['CODE'] == i)]
        temp = temp[temp['importance_Equipment'] == 'A']
        rate = temp['integrityrate_Equipment'].mean()
        A[i] = rate
    aRe = pd.DataFrame.from_dict(A, orient='index', columns=['integrityrate_Subsystem_ImpA']).reset_index()
    aRe.rename(columns={'index': 'CODE'}, inplace=True)
    subre = pd.merge(subre, aRe, how='left', on='CODE')
    subre['integrityrate_Subsystem_ImpA'] = subre['integrityrate_Subsystem_ImpA'].fillna(100)
    subre['integrityrate_Subsystem_final'] = subre.apply(
        lambda x: min(x['integrityrate_Subsystem'], x['integrityrate_Subsystem_ImpA']), axis=1)
    subre = subre[['CODE', 'integrityrate_Subsystem_final', 'integrityrate_Subsystem', 'integrityrate_Subsystem_ImpA']]
    name = weight[['CODE', 'SystemName','weights_system']]
    subre = pd.merge(name, subre, how='left', on='CODE')
    subre['integrityrate_Subsystem_final'].fillna(100, inplace=True)  # 填充空值
    subre['integrityrate_Subsystem_ImpA'].fillna(100, inplace=True)  # 填充空值
    subre['integrityrate_Subsystem'].fillna(100, inplace=True)  # 填充空值
    subre.rename(columns={'CODE': 'code_Subsystem', 'SystemName': 'name_Subsystem','weights_system':'weight_value'}, inplace=True)
    subre.dropna(subset=['integrityrate_Subsystem_final'], inplace=True)
    return subre


# 计算分系统级别结果(子系统结果，权重，等级判断标准)
def calMidsystem(subre, weight, criteria):
    # 分系统
    pa = weight['ParentSystem'].dropna().unique()
    w = weight[['CODE', 'SystemName', 'weights_system', 'ParentSystem']]
    subre.rename(columns={'code_Subsystem': 'CODE'}, inplace=True)
    midre = {}
    for i in pa:
        tempw = w[w['ParentSystem'] == i]
        a = pd.merge(subre, tempw, how='left', on='CODE')
        #a.dropna(subset=['integrityrate_Subsystem_final', 'weights_system'], inplace=True)
        midre[i] = ((a['integrityrate_Subsystem_final'] * a['weights_system']).sum()) / (
            a['weights_system'].sum())  # 数值*权重/权重合
    midresult = pd.DataFrame.from_dict(midre, orient='index', columns=['score']).reset_index()
    midresult.rename(columns={'index': 'name_Midsystem'}, inplace=True)
    midre = pd.merge(midresult, criteria, how='inner', on="name_Midsystem")
    grade = {}
    for sys in pa:
        grade[sys] = check_grade_Mid(midre[midre['name_Midsystem'] == sys])
    grade = pd.DataFrame.from_dict(grade, orient='index', columns=['grade'])
    grade.reset_index(inplace=True)
    grade.rename(columns={'index': 'name_Midsystem'}, inplace=True)

    midre.drop(
        ['id', 'Mid_I_Top', 'Mid_II_Top', 'Mid_III_Top', 'Mid_IV_Top', 'Mid_V_Top',
         'Mid_I_Bottom', 'Mid_II_Bottom', 'Mid_III_Bottom', 'Mid_IV_Bottom', 'Mid_V_Bottom'],
        axis=1, inplace=True)
    midSystem = pd.merge(midre, grade, how='inner', on='name_Midsystem')
    # midSystem.rename(
    #     columns={"mes_system_code": "mid_system_code", "mes_system_name": 'mid_system_name', 'score': 'mid_system_mark',
    #              'mes_system_status_index_code': 'mid_system_CI'},
    #     inplace=True)
    midSystem['score'].fillna(100, inplace=True)  # 填充空值
    paweight=weight[weight['LevelName']=='机电分系统']
    paweight=paweight[['SystemName','weights_system']]
    midSystem=pd.merge(paweight,midSystem,left_on='SystemName',right_on='name_Midsystem')
    midSystem.drop('SystemName',axis=1,inplace=True)
    midSystem.dropna(subset=['score'], inplace=True)
    midSystem.rename(columns={'weights_system':'weight_value'},inplace=True)
    return midSystem


# 计算机电系统评分(分系统级结果，权重表，判断标准)
def calMessystem(midSystem, weight, criteria,parameter):
    mid = midSystem[['name_Midsystem', 'score','grade']].copy()
    w = weight[['CODE', 'SystemName', 'weights_system', 'ParentSystem']]
    mid.rename(columns={'name_Midsystem': 'SystemName'}, inplace=True)
    mes = pd.merge(w, mid, how='left', on='SystemName')
    mes.dropna(subset=['score'], inplace=True)
    new_to_old={1:'I',2:'II',3:'III',4:'IV',5:'V'}
    def findA(code,level):
        temp=parameter[(parameter['code_Midsystem']== code ) & (parameter['parameter']=='aij')]
        temp.reset_index(inplace=True)
        return temp.loc[0,'MES_%s'%level]

    mes['aij'] = mes.apply(lambda x: findA(x.CODE, new_to_old[x.grade]), axis=1)
    def findB(code,level):
        temp = parameter[(parameter['code_Midsystem'] == code) & (parameter['parameter'] == 'bij')]
        temp.reset_index(inplace=True)
        return temp.loc[0, 'MES_%s' % level]

    mes['bij'] = mes.apply(lambda x: findB(x.CODE, new_to_old[x.grade]), axis=1)
    mes['score']= mes['score'].apply(lambda x: x/100)
    mes['score'] = mes['aij'] * (mes['score'] ** 2) + mes['bij']
    mes['score'] = mes['score'].apply(lambda x: round(x, 3))
    value = ((mes['score'] * mes['weights_system']).sum()) / (mes['weights_system'].sum())
    final = {}
    final['score'] = value
    final['CI_MESystem'] = 'JDCI'
    final['name_MESystem'] = '机电系统'
    final['code_MESystem'] = 'JDXT'
    final = pd.DataFrame(final, index=[0]).reset_index()
    final = pd.merge(final, criteria, how='inner', on=['CI_MESystem'])
    final['grade'] = check_grade_MES(final)
    # final.rename(columns={'mes_system_status_index_code': 'mes_system_CI'}, inplace=True)
    # final = final[['mes_system_code', 'mes_system_name', 'mes_system_CI', 'mes_system_score', 'mes_system_grade']]
    return final


def cal(task_no, start, end, project_code,is_insert=True):
    # 删除现有数据，避免存在重复结果
    mysql.clear_result_by_taskno(task_no=task_no
                                 , table_names=['tb_model_mes_result_equipment', 'tb_model_mes_result_subsystem',
                                                'tb_model_mes_result_midsystem','tb_model_mes_result_mesystem'])
    print("---------------删除数据成功--------------")

    #todo 计算单个设施

    dt = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")  # 读取现在时间（确定格式）
    conn = mysql.setconn()  # 连接数据库
    print('正在读取数据')
    # 基础数据
    start = datetime.datetime.strptime(start, '%Y-%m-%d %H:%M:%S')
    print(start)
    end = datetime.datetime.strptime(end, '%Y-%m-%d %H:%M:%S')
    # equipmentlist = pd.read_sql(
    #     "select * from tb_model_mes_equipmentlist  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
    #     conn)
    # 读数据库文件
    equipmentlist = pd.read_sql(
        "select * from tb_model_mes_equipmentlist  where project_code='" + project_code + "' ", conn)
    print(equipmentlist.shape)  # 输出数组大小
    operation = pd.read_sql(
        "select * from tb_model_mes_data_operation  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    print(operation.shape)
    # operation['start'] = operation.apply(lambda x: max(x.beginning_Operation, start), axis=1)
    # operation['end'] = operation.apply(lambda x: min(x.ending_Operation, end), axis=1)
    # operation['working_time'] = (operation['end'] - operation['start']).values / np.timedelta64(1, 'h')
    # operation = operation[operation['working_time'] > 0]
    operation.rename(columns={'total_Operation':'working_time'},inplace=True)
    failure = pd.read_sql(
        "select * from tb_model_mes_data_failure  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    print(failure.shape)
    failure.rename(columns={'total_Failure':'failure_time'},inplace=True)
    # if failure.empty:
    #     failure['failure_time']=None
    # else:
    #     failure['start'] = failure.apply(lambda x: max(x.beginning_Failure, start), axis=1)  # 轴
    #     failure['end'] = failure.apply(lambda x: min(x.ending_Failure, end), axis=1)
    #     failure['failure_time'] = (failure['end'] - failure['start']).values / np.timedelta64(1, 'h')  # 控制时间间隔
    #     failure = failure[failure['failure_time'] > 0]
    start = start.strftime('%Y-%m-%d %H:%M:%S')
    end = end.strftime('%Y-%m-%d %H:%M:%S')

    # 配置表
    weight = pd.read_sql('select * from tb_model_mes_systemtype_weights where facility_type="Bridge"', conn)

    imp = pd.read_sql("select * from tb_model_mes_devicetype_imp where  project_code='" + project_code + "' ", conn)
    # 分系统权重
    midcriteria = pd.read_sql("select * from tb_model_mes_criteria_midsystem where facility_type='Bridge' ", conn)
    # 机电系统权重
    mescriteria = pd.read_sql("select * from tb_model_mes_criteria_mesystem where facility_type='Bridge' ", conn)
    parameter = pd.read_sql("select * from tb_model_mes_parameter_mesystem where facility_type='Bridge' ", conn)

    # print('正在计算和插入各设备数量')
    # number = equipmentlist.groupby(['equipment_type_code'])['equipment_code'].count().reset_index()
    # equipname = imp[['equipment_type_code', 'equipment_type_name']].copy()
    # equipname['equipment_type_code'] = equipname['equipment_type_code'].str[-3:]
    # number.rename(columns={'equipment_code': 'equipment_count'}, inplace=True)
    # Number = pd.merge(number, equipname, how='left', on='equipment_type_code')
    # Number.dropna(subset=['equipment_type_name'], inplace=True)
    # Number['project_code'] = project_code
    # Number['task_no'] = task_no
    # Number['last_update_time'] = dt
    # Numbersql = 'insert into tb_mes_equipmentlist_num(project_code,task_no,equipment_type_code,equipment_count,equipment_type_name,last_update_time)' \
    #             ' values (%s,%s,%s,%s,%s,%s)'
    # mysql.insert(Number, Numbersql, conn)

    print('正在计算和插入设备级结果')  # result_equipment
    eqResult = calEquipment(equipmentlist, operation, failure, imp)
    eqResult['project_code'] = project_code
    eqResult['task_no'] = task_no
    eqResult['create_date'] = dt
    eqResult['start'] = start
    eqResult['end'] = end
    if is_insert == True:
        eqResultsql = 'insert into tb_model_mes_result_equipment(project_code,task_no,start,end,typeCode_Equipment,typeName_Equipment,' \
                    'importance_Equipment,integrityrate_Equipment,create_date)' \
                    ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        '''
        '''
        mysql.insert(eqResult, eqResultsql, conn)

    print('正在计算和插入子系统级结果')  # result_subsysem

    subre = calSubsysetm(eqResult, weight)
    subre['project_code'] = project_code
    subre['task_no'] = task_no
    subre['create_date'] = dt
    subre['start'] = start
    subre['end'] = end
    if is_insert == True:
        subresql = 'insert into tb_model_mes_result_subsystem(project_code,task_no,start,end,code_Subsystem,' \
                'name_Subsystem,integrityrate_Subsystem_final,integrityrate_Subsystem,integrityrate_Subsystem_ImpA,weight_value,create_date)' \
                ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(subre, subresql, conn)  # 插入数据库

    print('正在计算和插入分系统级结果')  # result_midsystem
    midSystem = calMidsystem(subre, weight, midcriteria)
    midSystem['project_code'] = project_code
    midSystem['task_no'] = task_no
    midSystem['create_date'] = dt
    midSystem['start'] = start
    midSystem['end'] = end
    if is_insert == True:
        midSystemsql = 'insert into tb_model_mes_result_midsystem(project_code,task_no,start,end,name_Midsystem,score,code_Midsystem,CI_Midsystem,grade,weight_value,create_date)' \
                    ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(midSystem, midSystemsql, conn)
    print('正在计算和插入机电系统结果')  # result_mesystem
    mesRe = calMessystem(midSystem, weight, mescriteria,parameter)
    mesRe['project_code'] = project_code
    mesRe['task_no'] = task_no
    mesRe['create_date'] = dt
    mesRe['start'] = start
    mesRe['end'] = end
    score = mesRe['score'].to_string()[5:15]
    grade = mesRe['grade'].to_string()[5:8]
    if is_insert == True:
        mesResql = 'insert into tb_model_mes_result_mesystem(project_code,task_no,start,end,code_MESystem,name_MESystem,CI_MESystem,score,grade,create_date)' \
                ' values (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(mesRe, mesResql, conn)
    if is_insert == True:
        conn.commit()
    conn.close()
    return score,grade
