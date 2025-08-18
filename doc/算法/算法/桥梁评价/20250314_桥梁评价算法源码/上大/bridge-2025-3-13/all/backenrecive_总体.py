import pika
import time
from pymysql import connect
import send
import os
import json
import mysql
import traceback
import pandas as pd
import tongji_points
import calculate_总体

def msg2(body):
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    status = 'Start'
    message = {'MainTaskNo': body['MainTaskNo'], 'ModelStatus': 'Run', 'GenDate': daytime}
    send.send(message, exchange, 'web','web')
    return daytime

def msg3(body, msgdate):
    print(body)
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    message = {'MainTaskNo': body['MainTaskNo'],'ModelStatus': 'Run', 'GenDate': daytime}
    send.send(message, exchange, 'web', 'web')
    return daytime

def msg4(body, msgdate):
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    status = 'Success'
    error = None
    main_taskno = body['MainTaskNo']
    tjzq_taskno= body['SubTaskNo']['tjzq_taskno']
    tjyq_taskno= body['SubTaskNo']['tjyq_taskno']
    jd_taskno=body['SubTaskNo']['jd_taskno']
    os_taskno=body['SubTaskNo']['os_taskno']
    af_taskno=body['SubTaskNo']['af_taskno']
    project_code = main_taskno[0:3]
    try:
        calculate_总体.cal_CI(project_code,main_taskno,tjzq_taskno, tjyq_taskno, jd_taskno,af_taskno,os_taskno)
    except Exception as e:
        status = 'Error'
        traceback.print_exc()
        error = str(e)
    message ={'MainTaskNo': body['MainTaskNo'],'ModelStatus': status, 'GenDate': daytime, 'ErrDesp': error}
    send.send(message, exchange, 'web','web')

exchange = 'MQ_Bridge_ALL'
queue = 'MQ_Bridge_ALL'
# 远程
username = 'rabbit_tbmp'
pwd = 'rabbit_tbmp'
user_pwd = pika.PlainCredentials(username, pwd)

def callback(channel, method, properity, body):
    print(body)
    body_json = json.loads(body)
    print(body_json)
    body_json = json.loads(body_json)
    print('received', body_json)
    #project_code=project_code[0:3]
    try:
        conn = mysql.setconn()
        # 总体表
        # re = pd.read_sql('select * from tb_model_overall_eval', conn)
        # task = re['main_taskno'].unique()
        # conn.close()
        # if body_json['MainTaskNo'] in task:
        #     status = 'Success'
        #     daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
        #     message = {'MainTaskNo': body_json['MainTaskNo'], 'ModelStatus': status, 'GenDate': daytime}
        #     send.send(message, exchange, 'web', 'web')
        # else:
        timem2 = msg2(body_json)
        timem3 = msg3(body_json, timem2)
        msg4(body_json, timem3)
        channel.basic_ack(delivery_tag=method.delivery_tag)

    except:
        traceback.print_exc()
        status = 'Error'
        daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
        message = {'MainTaskNo': body_json['MainTaskNo'], 'ModelStatus': status, 'GenDate': daytime,
                   'ErrDesp': 'Message data  is error!'}
        send.send(message, exchange, 'web', 'web')
        channel.basic_ack(delivery_tag=method.delivery_tag)

while True:
    try:
        connection = pika.BlockingConnection(
            pika.ConnectionParameters('172.16.193.70', credentials=user_pwd, heartbeat=0))
        connection.process_data_events()
        channel = connection.channel()
        channel.basic_qos(prefetch_count=1)
        channel.exchange_declare(exchange=exchange, exchange_type='direct', durable=False)
        channel.queue_declare(queue=queue, durable=True, auto_delete=False)
        channel.queue_bind(exchange=exchange, queue=queue, routing_key='backen')
        channel.basic_consume(on_message_callback=callback,queue=queue)
        channel.start_consuming()
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