import pymysql
import pandas as pd
from sqlalchemy import create_engine
import method
import json
from datetime import *
import calculate_structure_GLYQ
import calculate_structure_CSYQ
import calculate_structure_ZQ

# 定义数据库连接
conn = pymysql.Connect(host='121.41.10.16', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux', db='rcbi_model',
                       charset="utf8")
cursor = conn.cursor()
engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@121.41.10.16:3306/rcbi_model?charset=utf8")
task_no = 'MP3-20230201152656'  # 任务号
project_code = 'MP3'  # 项目号

cursor = conn.cursor()


def points_tujian(zq_task_no, yq_task_no):  # 输入为主桥任务号（string），引桥任务号（一维数组）
    # 定义数据库连接
    conn = pymysql.Connect(host='121.41.10.16', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux', db='rcbi_model',
                           charset="utf8")
    cursor = conn.cursor()
    engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@121.41.10.16:3306/rcbi_model?charset=utf8")
    points = []
    grade = []
    sql = 'select * from tb_bridge_assessment_output where task_no = "' + str(
        zq_task_no) + '" and code = "TOTAL"'  # 根据主桥任务号提取主桥计算结果
    df_zq = pd.read_sql(sql=sql, con=engine)
    zq_points = df_zq['points'].values[0]
    zq_grade = df_zq['grade'].values[0]
    points.append(zq_points)
    grade.append(zq_grade)
    for i in range(len(yq_task_no)):
        sql = 'select * from tb_bridge_assessment_output where task_no = "' + str(
            yq_task_no[i]) + '" and code = "TOTAL"'  # 根据引桥任务号提取引桥计算结果
        df_yq = pd.read_sql(sql=sql, con=engine)
        yq_points = df_yq['points'].values[0]
        yq_grade = df_yq['grade'].values[0]
        points.append(yq_points)
        grade.append(yq_grade)
    a = min(points)
    b=max(grade)
    return min(points), max(grade)  # 返回土建结构得分(float)和等级(int)


if __name__ == '__main__':

    conn = pymysql.Connect(host='172.16.193.70', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux', db='rcbi_model',
                           charset="utf8")
    cursor = conn.cursor()
    engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@172.16.193.70:3306/rcbi_model?charset=utf8")
    calculate_structure_ZQ.cal('SHSMP3-20241014050012', '1', '2', 'SHSMP3', conn, cursor, engine)
    cursor.close()
    conn.close()
    print('success')


