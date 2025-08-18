import re
import numpy as np

import pandas as pd
from pymysql import connect

def setconn(db='rcbi_model'):
    host = '172.16.193.70'
    port = 3306
    user = 'rcbi_2020'
    password = 'rcbi_all_2022_@#$$_123'
    charset = 'utf8'
    #远程
    conn = connect(host=host, port=port, db=db, user=user, password=password, charset=charset)
    #本地
    # conn = connect(host='localhost', port=3306, db='zyq',user='root', password='54827886lily', charset='utf8')
    return conn


def insert(df,sql,conn):
    cur = conn.cursor()
    col = re.findall('\(.*?\)', sql)[0]
    col = col.replace('(', '').replace(')', '')
    col = col.split(',')
    #print(col)
    for j in col:
        if df[j].dtypes == 'float64':
            df[j] = df[j].astype(np.float32)
    a = df[col].values.tolist()
    for i in range(len(a)):
        values = []
        for j in a[i]:
            values.append(j)

        cur.execute(sql, values)


def select(table,conn):
    df = pd.read_sql('SELECT * FROM %s;'%(table), conn)
    return df

#更新任务状态：ModelStatus：error、success
def update_mq_status(modelStatus,task_no):
    conn=setconn()
    cur = conn.cursor()
    update_sql="update tb_model_result_main set ModelStatus='{0}' where TaskNO='{1}'" \
                .format(modelStatus,task_no)
    cur.execute(update_sql)
    conn.commit()
    conn.close()

def update_mq_success(task_no):
    update_mq_status(modelStatus="success",task_no=task_no)

def update_mq_error(task_no):
    update_mq_status(modelStatus="error",task_no=task_no)
