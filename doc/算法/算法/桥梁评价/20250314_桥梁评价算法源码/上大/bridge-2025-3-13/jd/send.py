import pika
import json
import time
import pandas as pd
def send(body_dict,exchange,queue,rk):
    # # 本地
    #创建 connection 连接
    # connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    
    #远程
    username = 'rabbit_tbmp'
    pwd = 'rabbit_tbmp'
    user_pwd = pika.PlainCredentials(username, pwd)
    connection = pika.BlockingConnection(pika.ConnectionParameters('172.16.193.70', credentials=user_pwd,heartbeat=0))

    #在 connect 上创建一个 channel
    channel = connection.channel()
    #在 channel 上声明交换器 exchange
    channel.exchange_declare(exchange=exchange, exchange_type='direct', durable=False)
    #声明一个队列
    channel.queue_declare(queue=queue, durable=False, auto_delete=False)
    #通过键 rk 将队列和交换器绑定
    channel.queue_bind(exchange=exchange, queue=queue, routing_key=rk)
    # 列化成json数据，在队列中传输
    json_msg = json.dumps(body_dict)
    msg_props = pika.BasicProperties()
    msg_props.content_type = "application/json"
    channel.basic_publish(exchange=exchange, routing_key=rk, body=json_msg,
                          properties=msg_props)  # 确保消息是持久的，设置消息持久化，将要发送的消息的属性标记为2，表示该消息要持久化

    print('Send:',json_msg,'to',rk)
    connection.close()
