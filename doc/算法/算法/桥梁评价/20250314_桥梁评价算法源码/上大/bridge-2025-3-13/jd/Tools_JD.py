import mysql
import pandas as pd
import datetime
import threading
def cal_single_jd(task_no,project_code,datasource_startDate,datasource_endDate):

    #根据任务号task_no 清空tb_model_af_result_single 数据
    mysql.clear_result_by_taskno(task_no,['tb_model_mes_result_single'])

    conn = mysql.setconn()
    sql_cmd="""
    SELECT op.Equipment_Code, 
    op.Equipment_Name, 
    op.total_Operation,# 工作时间 
    f.total_Failure,# 故障时间 
    op.task_no,op.project_code
    FROM tb_model_mes_data_operation op
    LEFT JOIN tb_model_mes_data_failure f ON op.Equipment_Code = f.Equipment_Code 
    AND op.task_no = f.task_no 
    WHERE op.task_no = '{0}' 
    AND op.project_code = '{1}' 
    AND op.beginning_Operation = '{2}' 
    AND op.ending_Operation = '{3}' """.format(task_no,project_code,datasource_startDate,datasource_endDate)
    data = pd.read_sql(sql_cmd, conn)
    data['total_Failure'].fillna(0, inplace=True)
    data['Score']=(1-data['total_Failure']/data['total_Operation'])*100
    dt = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    data['create_date']=dt


    resultsql = 'insert into tb_model_mes_result_single (Equipment_Code,Equipment_Name,task_no,project_code,Score,create_date)' \
            'values (%s,%s,%s,%s,%s,%s)'
    mysql.insert(data, resultsql, conn)
    conn.commit()
    conn.close()
def start_cal_single_jd_task(task_no,project_code,datasource_startDate,datasource_endDate):
    thread = threading.Thread(target=cal_single_jd,
                              kwargs={"task_no": task_no, "project_code": project_code,
                                      "datasource_startDate": datasource_startDate, "datasource_endDate": datasource_endDate})
    thread.start()

if __name__ == '__main__':
    start_cal_single_jd_task("SHSMP3-20230918153303","SHSMP3",
                             "2020-01-01 00:00:00","2023-09-17 23:59:59")
    print("success")

