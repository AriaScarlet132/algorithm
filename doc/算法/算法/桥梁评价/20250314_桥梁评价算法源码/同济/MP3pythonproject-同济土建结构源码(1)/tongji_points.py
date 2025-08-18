import pymysql
import pandas as pd
from sqlalchemy import create_engine


def points_tujian(zq_task_no, yq_task_no):  # 输入为主桥任务号（一维数组），引桥任务号（一维数组）
    # 定义数据库连接
    conn = pymysql.Connect(host='172.16.193.70', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux', db='rcbi_model',
                           charset="utf8")
    cursor = conn.cursor()
    engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@172.16.193.70:3306/rcbi_model?charset=utf8")
    points = []
    grade = []
    for i in range(len(zq_task_no)):
        sql = 'select * from tb_bridge_assessment_output where task_no = "' + str(
            zq_task_no[i]) + '" and code = "TOTAL"'  # 根据主桥任务号提取主桥计算结果
        df_zq = pd.read_sql(sql=sql, con=engine)
        if df_zq.empty:
            points.append(0.0)
            grade.append(0.0)
            print("任务号: " + str(zq_task_no[i]) + "  未找到计算结果")
            return 0, 0
        else:
            zq_points = df_zq['points'].values[0]
            zq_grade = df_zq['grade'].values[0]
            points.append(zq_points)
            grade.append(zq_grade)

    for i in range(len(yq_task_no)):
        sql = 'select * from tb_bridge_assessment_output where task_no = "' + str(
            yq_task_no[i]) + '" and code = "TOTAL"'  # 根据引桥任务号提取引桥计算结果
        df_yq = pd.read_sql(sql=sql, con=engine)
        if df_yq.empty:
            points.append(0.0)
            grade.append(0.0)
            print("任务号: "+str(yq_task_no[i])+"  未找到计算结果")
            return 0, 0
        else:
            yq_points = df_yq['points'].values[0]
            yq_grade = df_yq['grade'].values[0]
            points.append(yq_points)
            grade.append(yq_grade)
    return min(points), max(grade)  # 返回土建结构得分(float)和等级(int)


# 调用示例
zq_task_no = ["SHSDH1-20240701074624","SHSDH1-20240701074057"]
yq_task_no = ["SHSDH1-20240701074719", "SHSDH1-20240701074655", "SHSDH1-20240701074603", "SHSDH1-20240701074543",
              "SHSDH1-20240701074521", "SHSDH1-20240701074459", "SHSDH1-20240701074406", "SHSDH1-20240701074336",
              "SHSDH1-20240701074211", "SHSDH1-20240701074138", "SHSDH1-20240701074021", "SHSDH1-20240701073817",
              "SHSDH1-20240701073723", "SHSDH1-20240701073651", "SHSDH1-20240701073529", "SHSDH1-20240701073458",
              "SHSDH1-20240701073429", "SHSDH1-20240701073338", "SHSDH1-20240701073122", "SHSDH1-20240701073046"]
tujian_points, tujian_grade = points_tujian(zq_task_no=zq_task_no, yq_task_no=yq_task_no)
print(tujian_points, tujian_grade)
