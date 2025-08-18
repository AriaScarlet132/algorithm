import mysql
import pandas as pd
import datetime
import warnings
warnings.filterwarnings("ignore")

def get_level():
    level_value=[1,2,3,4,5]
    level_name=[1,2,3,4,5]
    lower_value=[95,80,60,40,0]
    upper_value=[None,95,80,60,40]
    level={'level_value':level_value,'level_name':level_name,'lower_value':lower_value,'upper_value':upper_value}
    level=pd.DataFrame(level)
    return level

#计算子设施结果(设施清单，状况值，t——value，权重表)
def calCategory(facility, checkvalue, tvalue, weight):
    # 根据重要度生成扣分标准
    weights = weight[weight['Importance'].notnull()]
    weights = weights[weights['ParentType']!='/']
    imp = weights[['TypeCode', 'Importance']]
    catvalue = {'C': {1: 0, 2: 20, 3: 35},
                'B': {1: 0, 2: 25, 3: 40, 4: 50}}
    valuetable = pd.DataFrame.from_dict(catvalue).unstack()
    valuetable = valuetable.reset_index().rename(
        columns={'level_0': 'Importance', 'level_1': 'CheckMarkValue', 0: 'deductValue'})
    tvalue = tvalue[['n_num', 't_value']]
    facilitylist = facility[['FacilityCode', 'FacilityCategory_Name', 'FacilityCategory_Code']]
    checkvalue = checkvalue[['FacilityName_Code', 'CheckMarkValue']]
    facilitycheck = pd.merge(facilitylist, checkvalue, how='left', left_on='FacilityCode',right_on='FacilityName_Code')
    ded = pd.merge(facilitycheck, imp, how='left', left_on='FacilityCategory_Code', right_on='TypeCode')
    a = pd.merge(ded, valuetable, how='left', on=['CheckMarkValue', 'Importance'])
    a['deductValue'] = a['deductValue'].fillna(0)
    a['Value'] = 100 - a['deductValue']
    preresult = a.groupby('FacilityCategory_Code')['Value'].agg([
        ('meanValue', 'mean'),
        ('minValue', 'min'),
        ('Count','count')
    ]).reset_index()
    pre = pd.merge(preresult, tvalue, how='left', left_on='Count', right_on='n_num')
    # 数目为1，为本身
    pre['t_value'] = pre.apply(lambda x: 1 if x.Count == 1 else x.t_value, axis=1)
    # 数目大于200，和200一样
    pre['t_value'] = pre.apply(lambda x: 2.30 if x.Count > 200 else x.t_value, axis=1)
    pre['ranks'] = pre.apply(lambda x: x.meanValue - (100 - x.minValue) / x.t_value, axis=1)
    wcode=weights[['TypeCode', 'TypeName','Weight']].copy()
    wcode.rename(columns={'TypeCode':'FacilityCategory_Code','TypeName':'FacilityCategory_Name'},inplace=True)
    pre=pd.merge(wcode,pre,how='left')
    pre = pre[['FacilityCategory_Code', 'FacilityCategory_Name', 'ranks','Weight']]
    pre.rename(columns={'Weight':'weight_value'},inplace=True)
    pre['ranks'].fillna(100, inplace=True)  # 填充空值
    pre.dropna(inplace=True)
    return pre

#计算分设施结果(子设施结果，权重表)
def calType(preresult,weight):
    weights = weight[['TypeName', 'ParentType', 'TypeCode', 'Weight']]
    parent = weight[weight.ParentType=='/']
    parentcode = parent[['TypeName', 'TypeCode','Weight']]
    parentname = parentcode.TypeName.values
    typeresult = pd.merge(weights,preresult, how='left', right_on='FacilityCategory_Code', left_on='TypeCode')
    typeresult['value_type'] = typeresult['ranks'] * typeresult['Weight']
    resultdict = {}
    for name in parentname:
        temp = typeresult[(typeresult['ParentType'] == name) & (typeresult['value_type'].notnull())]
        resultdict[name] = temp['value_type'].sum() / temp['Weight'].sum()
    result = pd.DataFrame.from_dict(resultdict, orient='index',
                                    columns=['Value'])
    result = result.reset_index().rename(columns={'index': 'FacilityType_Name'})
    result = pd.merge(result, parentcode, how='left', left_on='FacilityType_Name', right_on='TypeName')
    result.drop('TypeName', axis=1, inplace=True)
    result['Value'].fillna(100, inplace=True)  # 填充空值
    result.rename(columns={'TypeCode': 'FacilityType_Code','Weight':'weight_value'}, inplace=True)
    result.dropna(inplace=True)
    return result

#计算总结果(分设施结果，权重表)
def calResult(presult,weight,level):
    parent =weight[weight.ParentType=='/']
    parent = parent[['TypeCode', 'Weight']]
    result = pd.merge(parent, presult, how='left', left_on='TypeCode', right_on='FacilityType_Code')
    result['mark_value_all'] = result['Value'] * result['Weight']
    result = result[result['mark_value_all'].notnull()]
    evaluate_mark = result['mark_value_all'].sum() / result['Weight'].sum()
    temp=level[(level['lower_value']<=evaluate_mark)& (evaluate_mark< level['upper_value'])]
    level=str(temp['level_name'].values[0])
    return evaluate_mark,level



#主函数(task_no,project_code)
def cal(task_no,project_code,is_insert=True):
    dt= datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    conn=mysql.setconn()
    print('正在读取数据')
    #taskNo+projectCode一起读取
    # facilitylist = pd.read_sql("select * from tb_af_facilitylist where project_code='" + project_code + "' and task_no='" + task_no + "' ", conn)
    #仅用projectCode读取
    facilitylist = pd.read_sql("select * from tb_model_af_facilitylist where project_code='" + project_code + "'  ", conn)
    print(facilitylist.shape)
    checkvalue = pd.read_sql(
        "select * from tb_model_af_facilitycheck_value where project_code='" + project_code + "' and task_no='" + task_no + "' ",
        conn)
    print(checkvalue.shape)
    checkvalue.drop_duplicates(subset=['FacilityName_Code'],keep='last',inplace=True)
    facilitylist.drop_duplicates(subset=['FacilityCode'],keep='last',inplace=True)
    tvalue = pd.read_sql('select * from tb_bridge_af_t_value ', conn)
    weight = pd.read_sql("select * from tb_model_af_type_weight where facility_type='Bridge' ", conn)
    weight.drop_duplicates(subset=['TypeCode', 'TypeName', 'Weight'], inplace=True)
    level=get_level()
    level['upper_value']=level['upper_value'].fillna(float('inf'))

    print('读取数据成功')
    print('正在计算和插入子设施评价结果')
    categoryresult= calCategory(facilitylist, checkvalue, tvalue, weight)
    categoryresult['project_code']=project_code
    categoryresult['task_no']=task_no
    categoryresult['create_date']=dt
    if is_insert == True:
        categoryresultsql='insert into tb_model_af_result_category (project_code,FacilityCategory_Code,FacilityCategory_Name,ranks,weight_value,task_no,create_date)' \
            'values (%s,%s,%s,%s,%s,%s,%s)'

        mysql.insert(categoryresult,categoryresultsql,conn)
    print('正在计算和插入分设施评价结果')
    typeresult=calType(categoryresult,weight)
    typeresult['project_code'] = project_code
    typeresult['task_no'] = task_no
    typeresult['create_date'] = dt
    if is_insert == True:
        typeresultsql='insert into tb_model_af_result_type (project_code,FacilityType_Code,FacilityType_Name,Value,weight_value,task_no,create_date)' \
            'values (%s,%s,%s,%s,%s,%s,%s)'
        mysql.insert(typeresult,typeresultsql,conn)
    print('正在计算和插入总体附属设施评价结果')
    mark,level=calResult(typeresult,weight,level)
    if is_insert == True:
        resultmysql='insert into tb_model_af_result' \
                    '(project_code,Code,Name,Value,Level,task_no,create_date)' \
                    'values(%s,%s,%s,%s,%s,%s,%s)'
        cur=conn.cursor()
        cur.execute(resultmysql,[project_code,'FSCI','附属设施',float(mark),level,task_no,dt])
    print(mark,level)
    if is_insert == True:
        conn.commit()
    conn.close()
    return mark,level