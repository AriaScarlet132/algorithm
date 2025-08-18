import mysql
import pandas as pd
import datetime
import threading


def cal_single_fs2(task_no,project_code):

    #根据任务号task_no 清空tb_model_af_result_single 数据
    mysql.clear_result_by_taskno(task_no,['tb_model_af_result_single'])

    conn = mysql.setconn()
    sql_cmd="""
    SELECT a.FacilityCategory_Name,a.FacilityCategory_Code,a.FacilityName,a.FacilityCode, a.project_code,b.CheckMarkValue , c.Importance from tb_model_bridge_af_facilitylist_2 a
    left join tb_model_bridge_af_facilitycheck_value_2 b
    on a.FacilityCode=b.FacilityName_Code
    and a.project_code=b.project_code
    and b.task_no='{0}'
    left join tb_model_bridge_af_type_weight_2 c
    on a.FacilityCategory_Code=c.TypeCode
    and c.facility_type='Bridge' and c.Level='子设施'
    where a.project_code='{1}' and c.Importance is not NULL""".format(task_no,project_code)




    data=pd.read_sql(sql_cmd,conn)
    data['CheckMarkValue'].fillna(1.0, inplace=True)
    catvalue = {'C': {1: 0, 2: 20, 3: 35},
                'B': {1: 0, 2: 25, 3: 40, 4: 50}}
    data['Score'] = 100 - data.apply(lambda row: catvalue[row['Importance']].get(row['CheckMarkValue'], 0), axis=1)
    data['task_no']=task_no
    data.drop(['CheckMarkValue','Importance'],axis=1,inplace=True)
    dt = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    data['create_date']=dt
    #插入数据

    resultsql='insert into tb_model_af_result_single (FacilityCategory_Name,FacilityCategory_Code,FacilityName,FacilityCode,project_code,Score,task_no,create_date)' \
            'values (%s,%s,%s,%s,%s,%s,%s,%s)'
    mysql.insert(data,resultsql,conn)
    conn.commit()
    conn.close()

def start_cal_single_fs2_task(task_no,project_code):
    thread = threading.Thread(target=cal_single_fs2,
                              kwargs={"task_no": task_no, "project_code": project_code})
    thread.start()

if __name__ == '__main__':
    start_cal_single_fs2_task("SHSMP3-20240325061911","SHSMP3")
    print("success")