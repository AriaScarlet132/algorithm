import pika
import time
from pymysql import connect
import calculate_机电
import send
import os
import json
import mysql
import traceback
import pandas as pd

def msg2(body):
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    # cur=conn.cursor()
    # # sql = "update tb_model_FIN_Result_Main set ModelStatus = %s,DataInserter='Python', DataInsertTime=%s' \
    # #       'where TaskNO =%s"
    #
    status = 'Start'
    # sql = 'insert into tb_model_mes_result_main(TaskNO,DataSource_StartDate,DataSource_EndDate,ProjectID,Model_Type,ModelStatus,MsgDate,' \
    #       'DataInserter,DataInsertTime)values ' \
    #       '(%s,%s,%s,%s,%s,%s,%s,%s,%s)'
    #
    # cur.execute(sql, [body['TaskNO'],body['DataSource_StartDate'],body['DataSource_EndDate'],body['ProjectID'],
    #                   body['Model_Type'],status,body['GenDate'],'Python',daytime])
    message = {'TaskNO': body['TaskNO'], 'ModelStatus': status, 'GenDate': daytime}
    send.send(message, exchange, 'web','web')
    return daytime

def msg3(body, msgdate):
    print(body)
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    # cur=conn.cursor()
    message = {'TaskNO': body['TaskNO'], 'ModelStatus': 'Run', 'GenDate': daytime}
    # # sql = "update tb_model_FIN_Result_Main set ModelStatus = %s,DataInserter='Python', DataInsertTime=%s' \
    # #           'where TaskNO =%s"
    # sql = 'insert into tb_model_mes_result_main(TaskNO,ProjectID,Model_Type,ModelStatus ' \
    #       ',MsgDate,DataInserter,' \
    #       'DataInsertTime,ConfigID)values ' \
    #       '(%s,%s,%s,%s,%s,%s,%s,%s)'
    status = 'Run'
    # cur.execute(sql, [body['TaskNO'],body['ProjectID'],body['Model_Type'],
    #                   status,msgdate,'Python',daytime,body['ConfigID']])
    send.send(message, exchange, 'web','web')
    return daytime


def msg4(body, msgdate):
    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
    # cur=conn.cursor()
    status = 'Success'
    error = None
    try:
        calculate_机电.cal(body['TaskNO'], body['DataSource_StartDate'], body['DataSource_EndDate'], body['ProjectID'])
        mysql.update_mq_success(body['TaskNO'])
    except Exception as e:
        status = 'Error'
        traceback.print_exc()
        error = str(e)
        mysql.update_mq_error(body['TaskNO'])

    message = {'TaskNO': body['TaskNO'], 'ModelStatus': status, 'GenDate': daytime, 'ErrDesp': error}
    # if ErrDesp:
    #     message['ErrDesp']=ErrDesp
    # else:
    #     message['ErrDesp']=None
    # sql = 'insert into tb_model_mes_result_main(TaskNO,ProjectID,ConfigID,Model_Type,ModelStatus ' \
    #       ',ErrMsg,MsgDate,DataInserter,' \
    #       'DataInsertTime)values ' \
    #       '(%s,%s,%s,%s,%s,%s,%s,%s,%s)'
    # # sql = "update tb_model_FIN_Result_Main set ModelStatus = %s,DataInserter='Python', DataInsertTime=%s' \
    # #               'where TaskNO =%s"
    # cur.execute(sql, [body['TaskNO'],body['ProjectID'],body['ConfigID'],body['Model_Type'], status,message['ErrDesp'],msgdate,'Python',daytime])
    send.send(message, exchange, 'web','web')


exchange = 'MQ_Bridge_JDEVA'
queue = 'MQ_Bridge_JDEVA'

#本地
# connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost',heartbeat=0))
# 远程
username = 'rabbit_tbmp'
pwd = 'rabbit_tbmp'
user_pwd = pika.PlainCredentials(username, pwd)

def callback(channel, method, properity, body):
    print(body)
    body_json = json.loads(body)
    try:
        model=body_json['Model_Type']
    except:
        body_json = json.loads(body_json)
    print('received', body_json)
    try:
        if body_json['Facility_Type'] == 'Bridge':
            if body_json['Model_Type'] == 'JDEVA':
                conn = mysql.setconn()
                # 总体结果表
                re = pd.read_sql('select * from tb_model_mes_result_mesystem', conn)
                task = re['task_no'].unique()
                conn.close()
                if body_json['TaskNO'] in task:
                    status = 'Success'
                    daytime = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time()))
                    message = {'TaskNO': body_json['TaskNO'], 'ModelStatus': status, 'GenDate': daytime}
                    #mysql.update_mq_success(body_json['TaskNO'])
                    timem2 = msg2(body_json)
                    timem3 = msg3(body_json, timem2)
                    msg4(body_json, timem3)
                    send.send(message, exchange, 'web', 'web')
                else:
                    timem2 = msg2(body_json)
                    timem3 = msg3(body_json, timem2)
                    msg4(body_json, timem3)
                channel.basic_ack(delivery_tag=method.delivery_tag)
            else:
                print('%s模型不属于机电评估模型' % body_json['Model_Type'])
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
