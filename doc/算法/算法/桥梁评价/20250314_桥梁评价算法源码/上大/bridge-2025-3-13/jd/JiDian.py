import pandas as pd
import mysql
import warnings
import numpy as np
import datetime
warnings.filterwarnings("ignore")

# 计算设备级结果（设施清单，失败时间，设备重要度）
def calEquipment(eq,start,end,eqf,imp):
    imp=imp.rename(columns={'typeName_Equipment':'TypeName_Equipment','typeCode_Equipment':'TypeCode_Equipment'})
    eq=eq.rename(columns={'typeCode_Equipment':'TypeCode_Equipment','typeName_Equipment':'TypeName_Equipment'})
    #计算统计周期时长
    oph = ((end - start).days+1)*24
    fail = eqf[['Equipment_Code', 'total_Failure']].copy()
    eqlist = eq[['TypeCode_Equipment','TypeName_Equipment','Equipment_Code']].copy()
    eqlist=pd.merge(eqlist,fail,how='left',on='Equipment_Code')
    eqre=pd.pivot_table(eqlist,index=['TypeCode_Equipment','TypeName_Equipment'],values='total_Failure',aggfunc=np.sum)
    eqre.reset_index(inplace=True)
    eqre['integrityrate_Equipment']=1-eqre['total_Failure']/oph
    eqre=pd.merge(eqre,imp[['MesSystemCode','TypeCode_Equipment','importance_Equipment']],how='left',on='TypeCode_Equipment')
    return eqre

# 计算子系统级结果 （设备级结果，权重表）
def calSubsysetm(eq,eqf,imp,weight,start,end):
    # 计算统计周期时长
    imp = imp.rename(columns={'typeName_Equipment': 'TypeName_Equipment', 'typeCode_Equipment': 'TypeCode_Equipment'})
    eq = eq.rename(columns={'typeCode_Equipment': 'TypeCode_Equipment', 'typeName_Equipment': 'TypeName_Equipment'})
    w=weight[weight['LevelName']=='机电子系统'].copy()
    oph = ((end - start).days + 1) * 24
    fail = eqf[['Equipment_Code', 'total_Failure']].copy()
    eqlist = eq[['TypeCode_Equipment', 'TypeName_Equipment', 'Equipment_Code']].copy()
    eqlist = pd.merge(eqlist, fail, how='left', on='Equipment_Code')
    eqlist['N']=1
    eqlist['code_Subsystem']=eqlist['Equipment_Code'].str[8:11]
    eqlist = pd.merge(eqlist, imp[['TypeCode_Equipment', 'importance_Equipment']], how = 'left',
                                                                                  on = 'TypeCode_Equipment')
    subre=pd.pivot_table(eqlist,index=['code_Subsystem'],values=['total_Failure','N'],aggfunc=np.sum)
    subre.reset_index(inplace=True)
    subre['integrityrate_Subsystem']=1-(subre['total_Failure']/(oph*subre['N']))
    systems=subre['code_Subsystem'].unique()
    A={}
    for s in systems:
        temp= eqlist[eqlist['code_Subsystem']==s]
        temp=temp[temp['importance_Equipment']=='A']
        if temp.empty:
            A[s]=100
        else:
            re=pd.pivot_table(temp, index=['code_Subsystem'], values=['total_Failure', 'N'], aggfunc=np.sum)
            re.reset_index(inplace=True)
            rate=1-(re['total_Failure']/(oph*re['N']))
            A[s]=rate.values[0]
    aRe = pd.DataFrame.from_dict(A, orient='index', columns=['integrityrate_Subsystem_ImpA']).reset_index()
    aRe.rename(columns={'index': 'code_Subsystem'}, inplace=True)
    subre=pd.merge(subre,aRe,how='left',on='code_Subsystem')
    subre['integrityrate_Subsystem_final']=subre.apply(lambda x: min(x.integrityrate_Subsystem,x.integrityrate_Subsystem_ImpA),axis=1)
    subre=subre[['code_Subsystem','integrityrate_Subsystem','integrityrate_Subsystem_ImpA','integrityrate_Subsystem_final']]
    subre=pd.merge(subre,w[['CODE','SystemName']],how='left',left_on='code_Subsystem',right_on='CODE')
    return subre

# 计算分系统级别结果(子系统结果，权重，等级判断标准)
def calMidsystem(subre, weight, criteria):
    w = weight[['CODE', 'SystemName', 'weights_system', 'ParentSystem']]
    #分系统
    pa = weight['ParentSystem'].dropna().unique()
    midre={}
    for i in pa:
        tempw = w[w['ParentSystem'] == i]
        a = pd.merge(tempw,subre , how='left', on='CODE')
        a.dropna(subset=['integrityrate_Subsystem_final', 'weights_system'], inplace=True)
        midre[i] = ((a['integrityrate_Subsystem_final'] * a['weights_system']).sum()) / (
            a['weights_system'].sum())  # 数值*权重/权重合
    midresult = pd.DataFrame.from_dict(midre, orient='index', columns=['score']).reset_index()
    midresult.rename(columns={'index': 'code_Midsystem'}, inplace=True)
    midresult.dropna(subset=['score'],inplace=True)
    midresult=pd.merge(midresult,w[['CODE','SystemName']],how='left',left_on='code_Midsystem',right_on='CODE')
    #判断等级
    def defineLevel(system,score):
        if score==1:
            return 'I'
        else:
            temp=criteria[criteria['mes_system_code']==system]
            temp= temp[(temp['low_value'] <= score) & (score <temp['up_value'])]
            temp.reset_index(inplace=True)
            return temp.loc[0, 'Level']
    midresult['grade']=midresult.apply(lambda x: defineLevel(x.code_Midsystem,x.score),axis=1)
    return midresult


# 计算机电系统评分(分系统级结果，权重表，判断标准)
def calMessystem(midSystem, weight, criteria,parameter):
    midre=midSystem[['score','CODE','grade']].copy()
    wpa=weight[weight['LevelName']=='机电分系统']
    midre=pd.merge(midre,wpa[['CODE','weights_system']],how='left',on='CODE')
    midre.dropna(subset=['score'],inplace=True)
    def findA(code,level):
        temp=parameter[(parameter['code_Midsystem']== code ) & (parameter['parameter']=='aij')]
        temp.reset_index(inplace=True)
        return temp.loc[0,'MES_%s'%level]
    midre['aij']=midre.apply(lambda x:findA(x.CODE,x.grade),axis=1)
    def findB(code,level):
        temp = parameter[(parameter['code_Midsystem'] == code) & (parameter['parameter'] == 'bij')]
        temp.reset_index(inplace=True)
        return temp.loc[0, 'MES_%s' % level]
    midre['bij'] = midre.apply(lambda x: findB(x.CODE, x.grade), axis=1)
    midre['score']=midre['aij']*(midre['score']**2)+midre['bij']
    midre['score']=midre['score'].apply(lambda x: round(x,3))
    JDCI=(midre['score']*midre['weights_system']).sum()/(midre['weights_system'].sum())
    if JDCI == 100:
        level = 'I'
    else:
        temp = criteria[criteria['mes_system_code']=='JDXT']
        temp = temp[(temp['low_value'] <= JDCI) & (JDCI < temp['up_value'])]
        temp.reset_index(inplace=True)
        level= temp.loc[0, 'Level']
    final = {}
    final['score'] = JDCI
    final['CI_MESystem'] = 'JDCI'
    final['name_MESystem'] = '机电系统'
    final['code_MESystem'] = 'JDXT'
    final['grade']=level
    final = pd.DataFrame(final, index=[0]).reset_index()
    return final

def cal(project_code,start,end,task_no):
    conn=mysql.setconn()
    dt = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")  # 读取现在时间（确定格式）
    # 基础数据
    start = datetime.datetime.strptime(start, '%Y-%m-%d %H:%M:%S')
    end = datetime.datetime.strptime(end, '%Y-%m-%d %H:%M:%S')
    # 读数据库文件
    equipmentlist = pd.read_sql(
        "select * from tb_model_mes_equipmentlist  where project_code='" + project_code + "' ", conn)
    failure = pd.read_sql(
        "select * from tb_model_mes_data_failure  where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    # 配置表    
    #权重表
    weight = pd.read_sql('select * from tb_model_mes_systemtype_weights where facility_type="Bridge"', conn)
    #设备重要度
    imp = pd.read_sql("select * from tb_model_mes_devicetype_imp where  project_code='" + project_code + "' ", conn)
    # 分系统权重
    midcriteria = pd.read_sql("select * from tb_model_mes_criteria_midsystem where facility_type='Bridge' ", conn)
    # 机电系统权重
    mescriteria = pd.read_sql("select * from tb_model_mes_criteria_mesystem where facility_type='Bridge' ", conn)

    # 分系统权重
    midcriteria = pd.read_sql("select * from tb_model_mes_criteria_midsystem where facility_type='Bridge' ", conn)
    #分系统分数权重
    criteria=pd.read_sql("select * from tb_model_mes_criteria ", conn)
    #分系统系数
    parameter=pd.read_sql("select * from tb_model_mes_parameter_mesystem where facility_type='Bridge' ", conn)
    print('计算设备级别结果')
    eqre=calEquipment(equipmentlist,start,end,failure,imp)
    print('计算子系统级别结果')
    subre=calSubsysetm(equipmentlist,failure,imp,weight, start, end)
    print('计算分系统级别结果')
    midre=calMidsystem(subre, weight, criteria)
    midre=pd.merge(midre,midcriteria[['code_Midsystem','CI_Midsystem']],how='left',on='code_Midsystem')
    print('计算机电系统级别结果')#总体合并的时候系数注意
    final=calMessystem(midre, weight, criteria, parameter)

    print('结果插入数据库')
    start = start.strftime('%Y-%m-%d %H:%M:%S')
    end = end.strftime('%Y-%m-%d %H:%M:%S')
    eqre['start']=start
    eqre['end']=end
    eqre['project_code']=project_code
    eqre['task_no']=task_no
    eqre['create_date'] = dt
    mysql.insert(eqre,'insert into tb_model_mes_result_equipment (start,end,TypeName_Equipment,'
                      'TypeCode_Equipment,importance_Equipment,integrityrate_Equipment,project_code,task_no,create_date) values (%s,%s,%s,%s,%s,%s,%s,%s,%s)',conn)
    subre['start'] = start
    subre['end'] = end
    subre['project_code'] = project_code
    subre['task_no'] = task_no
    subre['create_date'] = dt
    subre.rename(columns={'SystemName':'name_Subsystem'},inplace=True)
    mysql.insert(subre,'insert into tb_model_mes_result_subsystem(code_Subsystem,integrityrate_Subsystem,integrityrate_Subsystem_ImpA,integrityrate_Subsystem_final,name_Subsystem,start,end,project_code,task_no,create_date)  '
                       'values(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)',conn)
    midre['start'] = start
    midre['end'] = end
    midre['project_code'] = project_code
    midre['task_no'] = task_no
    midre['create_date'] = dt
    midre.rename(columns={'SystemName':'name_Midsystem'},inplace=True)
    mysql.insert(midre,'insert into tb_model_mes_result_midsystem(name_Midsystem,code_Midsystem,CI_Midsystem,score,grade,start,end,project_code,task_no,create_date)  '
                       'values(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)',conn)
    final['start'] = start
    final['end'] = end
    final['project_code'] = project_code
    final['task_no'] = task_no
    final['create_date'] = dt
    mysql.insert(final,'insert into tb_model_mes_result_mesystem(start,end,name_MESystem,code_MESystem,CI_MESystem,score,grade,project_code,task_no,create_date)'
                        'values(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)',conn)
    conn.commit()
    conn.close()




