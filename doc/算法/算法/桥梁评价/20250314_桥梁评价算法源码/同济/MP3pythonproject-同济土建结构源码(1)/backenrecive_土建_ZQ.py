import pika
import time
from pymysql import connect
import pymysql
from sqlalchemy import create_engine

import calculate_structure_ZQ  # 主桥结构的计算函数，对应msg4
import send
import os
import json
import traceback
import warnings
import pandas as pd

warnings.filterwarnings("ignore")


def msg2(body):
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    status = 'Start'
    message = {'TaskNO': body['TaskNO'], 'ModelStatus': status, 'GenDate': daytime}
    send.send(message, exchange, 'web', 'web')
    return daytime


def msg3(body, msgdate):
    print(body)
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    message = {'TaskNO': body['TaskNO'], 'ModelStatus': 'Run', 'GenDate': daytime}
    status = 'Run'
    send.send(message, exchange, 'web', 'web')
    return daytime


def msg4(body, msgdate):  # 主桥结构的计算函数
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    status = 'Success'
    error = None
    try:
        # 修改2   土建评价函数（传入4个参数)——已修改
        # 定义数据库连接
        conn = pymysql.Connect(host='127.0.0.1', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux', db='rcbi_model',
                               charset="utf8")
        engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@127.0.0.1:3306/rcbi_model?charset=utf8")
        cursor = conn.cursor()
        calculate_structure_ZQ.cal(body['TaskNO'], body['DataSource_StartDate'], body['DataSource_EndDate'],
                                body['ProjectID'], conn, cursor, engine)
        cursor.close()
        conn.close()
    except Exception as e:
        status = 'Error'
        traceback.print_exc()
        error = str(e)

    message = {'TaskNO': body['TaskNO'], 'ModelStatus': status, 'GenDate': daytime, 'ErrDesp': error}
    send.send(message, exchange, 'web', 'web')


def callback(channel, method, properity, body):
    print(body)
    body_json = json.loads(body)
    print(body_json)
    body_json = json.loads(body_json)
    print('received', body_json)
    try:
        if body_json['Facility_Type'] == 'Bridge_ZQ':  # 如果是主桥的评价
            if body_json['Model_Type'] == 'TJEVA':
                # 定义数据库连接
                conn = pymysql.Connect(host='127.0.0.1', port=3306, user='tj', password='YoG5ti0L2CM7Z8ux',
                                       db='rcbi_model',
                                       charset="utf8")
                engine = create_engine("mysql+pymysql://tj:YoG5ti0L2CM7Z8ux@127.0.0.1:3306/rcbi_model?charset=utf8")
                cursor = conn.cursor()
                # conn = mysql.setconn()
                # 修改3
                # select * from tb_model_op_bridge_result_all_evaluation 修改成评价对象的结果表——已修改
                # 如果taskno存在，就不评价，如果task_no不存在，就进行评价，插入评价结果数据
                re = pd.read_sql(sql='select * from tb_bridge_assessment_output', con=engine)
                task = re['task_no'].unique()
                cursor.close()
                conn.close()
                if body_json['TaskNO'] in task:
                    status = 'Success'
                    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
                    message = {'TaskNO': body_json['TaskNO'], 'ModelStatus': status, 'GenDate': daytime}
                    send.send(message, exchange, 'web', 'web')
                else:
                    timem2 = msg2(body_json)
                    timem3 = msg3(body_json, timem2)
                    msg4(body_json, timem3)  # 调用主桥计算函数
                channel.basic_ack(delivery_tag=method.delivery_tag)
            else:
                print('%s模型不属于土建评估模型' % body_json['Model_Type'])
                status = 'Disable'
                daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
                message = {'TaskNO': body_json['TaskNO'], 'ModelStatus': status, 'GenDate': daytime}
                send.send(message, exchange, 'web', 'web')
                channel.basic_ack(delivery_tag=method.delivery_tag)

        else:
            print('%s模型不属于桥梁评估模型' % body_json['Facility_Type'])
            status = 'Disable'
            daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
            message = {'TaskNO': body_json['TaskNO'], 'ModelStatus': status, 'GenDate': daytime}
            send.send(message, exchange, 'web', 'web')
            channel.basic_ack(delivery_tag=method.delivery_tag)


    except:
        traceback.print_exc()
        status = 'Error'
        daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
        message = {'TaskNO': body_json['TaskNO'], 'ModelStatus': status, 'GenDate': daytime,
                   'ErrDesp': 'Message data  is error!'}
        send.send(message, exchange, 'web', 'web')
        channel.basic_ack(delivery_tag=method.delivery_tag)


# 远程
"""
exchange = 'MQ_Bridge_TJEVA'
queue = 'MQ_Bridge_TJEVA'
username = 'rabbit_tbmp'
pwd = 'rabbit_tbmp'
user_pwd = pika.PlainCredentials(username, pwd)
connection = pika.BlockingConnection(pika.ConnectionParameters('127.0.0.1', credentials=user_pwd, heartbeat=0))
connection.process_data_events()
channel = connection.channel()
channel.basic_qos(prefetch_count=1)
channel.exchange_declare(exchange=exchange, exchange_type='direct', durable=False)
channel.queue_declare(queue=queue, durable=True, auto_delete=False)
channel.queue_bind(exchange=exchange, queue=queue, routing_key='backen')

channel.basic_consume(on_message_callback=callback, queue=queue)
channel.start_consuming()
"""

exchange = 'MQ_Bridge_ZQ_TJEVA'
queue = 'MQ_Bridge_ZQ_TJEVA'
username = 'rabbit_tbmp'
pwd = 'rabbit_tbmp'
user_pwd = pika.PlainCredentials(username, pwd)
while True:
    try:
        connection = pika.BlockingConnection(
            pika.ConnectionParameters('127.0.0.1', credentials=user_pwd, heartbeat=0))
        connection.process_data_events()
        channel = connection.channel()
        channel.basic_qos(prefetch_count=1)
        channel.exchange_declare(exchange=exchange, exchange_type='direct', durable=False)
        channel.queue_declare(queue=queue, durable=True, auto_delete=False)
        channel.queue_bind(exchange=exchange, queue=queue, routing_key='backen')
        channel.basic_consume(on_message_callback=callback, queue=queue)
        channel.start_consuming()
        # Don't recover if connection was closed by broker
    except pika.exceptions.ConnectionClosedByBroker as e:
        print(str(e))
        continue
        # Don't recover on channel errors
    except pika.exceptions.AMQPChannelError as e:
        print(str(e))
        continue
        # Recover on all other connection errors
    except pika.exceptions.AMQPConnectionError as e:
        print(str(e))
        continue