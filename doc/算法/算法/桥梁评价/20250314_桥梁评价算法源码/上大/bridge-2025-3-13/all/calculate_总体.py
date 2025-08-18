import mysql
import pandas as pd
import numpy as np
import datetime
import warnings
import tongji_points
import time
import utils
import calculate_机电
import calculate_运营
import calculate_附属

warnings.filterwarnings("ignore")

# 计算总体等级
def check_grade_ALL(CI):
    conn = mysql.setconn()  # 连接数据库
    df = pd.read_sql(
        "select * from tb_model_bridge_all_evaluation_criteria_level where evaluation_code = 'Bridge_ALL' ", conn)
    CI = float(CI)
    if (CI >= df['lower_value'][0]):
        return 1
    if ((CI >= df['lower_value'][1]) & (CI < df['upper_value'][1])):
        return 2
    if ((CI >= df['lower_value'][2]) & (CI < df['upper_value'][2])):
        return 3
    if ((CI >= df['lower_value'][3]) & (CI < df['upper_value'][3])):
        return 4
    if (CI < df['upper_value'][4]):
        return 5

def points_af(af_task_no):  # 输入为附属任务号
    conn = mysql.setconn()  # 连接数据库
    n = pd.read_sql("SELECT 1 FROM tb_model_af_result WHERE task_no = '" + af_task_no + "' ",conn)
    if(n.empty != True):
        af_result = pd.read_sql(
        "select * from tb_model_af_result where task_no = '" + af_task_no + "' ",conn)
        afresult = af_result['Value']
        afgrade = af_result['Level']
        pd.to_numeric(afresult, errors='coerce')
        pd.to_numeric(afgrade, errors='coerce')
    else:
        start, end, project_code=utils.get_model_result_main(conn,af_task_no)
        afresult,afgrade=calculate_附属.cal(af_task_no,project_code, is_insert=False)
        print(afresult,afgrade)
    print("获取附属分数等级成功")
    return afresult,afgrade

def points_jd(mes_task_no):  # 输入为机电任务号
    conn = mysql.setconn()  # 连接数据库
    n = pd.read_sql("SELECT 1 FROM tb_model_mes_result_mesystem WHERE task_no = '" + mes_task_no + "' ", conn)
    if (n.empty != True):
        mes_result = pd.read_sql(
        "select * from tb_model_mes_result_mesystem where task_no = '" + mes_task_no + "' ",conn)
        mesresult = mes_result['score']
        mesgrade=mes_result['grade']
        pd.to_numeric(mesresult, errors='coerce')
        pd.to_numeric(mesgrade, errors='coerce')
    else:
        start, end, project_code=utils.get_model_result_main(conn,mes_task_no)
        mesresult,mesgrade=calculate_机电.cal(mes_task_no, start, end, project_code, is_insert=False)
        print(mesresult,mesgrade)
    print("获取机电分数等级成功")
    return mesresult,mesgrade

def points_os(os_task_no):  # 输入为运营任务号
    conn = mysql.setconn()  # 连接数据库
    n = pd.read_sql("SELECT 1 FROM tb_model_op_bridge_result_all_evaluation WHERE task_no = '" + os_task_no + "' ", conn)
    if (n.empty != True):
        os_result = pd.read_sql(
            "select * from tb_model_op_bridge_result_all_evaluation where task_no = '" + os_task_no + "' ",conn)
        osresult = os_result['fwci_value']
        osgrade = os_result['fwci_level']
        pd.to_numeric(osresult, errors='coerce')
        pd.to_numeric(osgrade, errors='coerce')
    else:
        start, end, project_code=utils.get_model_result_main(conn,os_task_no)
        osresult,osgrade=calculate_运营.cal(os_task_no, start, end, project_code, is_insert=False)
        print(osresult,osgrade)
    print("获取运营分数等级成功")
    return osresult,osgrade

def cal_CI(project_code,main_taskno,zq_task_no, yq_task_no,mes_task_no,af_task_no,os_task_no):
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    conn = mysql.setconn()  # 连接数据库
    weight = pd.read_sql('select * from tb_bridge_all_evaluation_weight where project_code = project_code', conn)
    tjresult,tjgrade = tongji_points.points_tujian(zq_task_no, yq_task_no)
    print('获取土建分数等级成功')
    afresult,afgrade = points_af(af_task_no)
    osresult,osgrade = points_os(os_task_no)
    mesresult,mesgrade = points_jd(mes_task_no)
    CI = mesresult * weight['jd_weight'] + osresult * weight['os_weight'] + afresult * weight['af_weight'] + tjresult * weight['tj_weight']
    CII = CI.astype(np.float64)
    CI=CII.to_string()[5:12]
    CIgrade=check_grade_ALL(CI)
    print(CII,'\n',"总分计算成功")
    print("正在更新总分结果")
    cur = conn.cursor()
    update = ("UPDATE tb_model_overall_eval SET af_mark = %f ,os_mark = %f ,jd_mark = %f,tj_mark = %f WHERE main_taskno = '%s'" %(afresult,osresult,mesresult, tjresult,main_taskno))
    update2 = ("UPDATE tb_model_overall_eval SET af_grade = %d ,os_grade = %d ,jd_grade = %d,tj_grade = %d, total_grade= %d WHERE main_taskno = '%s'" %(afgrade,osgrade,mesgrade,tjgrade,CIgrade,main_taskno))
    update3 = ("UPDATE tb_model_overall_eval SET total_mark = %f , last_update = '%s' WHERE main_taskno = '%s'" % (CII,daytime,main_taskno))
    update4 = ("UPDATE tb_model_overall_eval SET status = 'Success' , error_msg = ''  WHERE main_taskno = '%s'" % (main_taskno))
    cur.execute(update)
    cur.execute(update2)
    cur.execute(update3)
    cur.execute(update4)
    conn.commit()
    conn.close()
    print("更新成功")
    return CI,CIgrade

# cal_CI("MP3","MP3-202350410134332","MP3-20230407162424",['MP3-20230407162459','MP3-20230407162449','MP3-20230407162430','MP3-20230407162427'],'MP3-20230410111942','MP3-20230410112213','MP3-20230410112443')
# "MP3-20230331011021","MP3-20230322172815",['MP3-20230328162525', 'MP3-20230328162531'],"MP3-20230201143852",  "MP3-20221028145942", "MP3-20221208121804")

# points_jd('MP3-20230422030032',)
# points_af('MP3-20230423024024')
# points_os('MP3-20230422030200')

#def cal_CI(project_code,main_taskno,zq_task_no, yq_task_no,mes_task_no,af_task_no,os_task_no):
if __name__ == '__main__':
   cal_CI("SHSMP3","SHSMP3-20240226080015",
          "SHSMP3-20240226060008"
          ,["SHSMP3-20240226061226","SHSMP3-20240226061102","SHSMP3-20240226060920","SHSMP3-20240226060747"]
          ,'SHSMP3-20240226061326',
          'SHSMP3-20240226061315',
          'SHSMP3-20240226061340')
