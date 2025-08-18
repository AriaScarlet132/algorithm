using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.iisp.Publisher.impl
{
    /// <summary>
    /// 消息订阅者/消费者。
    /// </summary>
    public class RabbitMQSubscriber : ISubscriber
    {
        private readonly RabbitMQProvider _provider;
        private IConnection _connection;
        public RabbitMQSubscriber(RabbitMQProvider provider)
        {
            _provider = provider;
            _connection = _provider.ConnectionFactory.CreateConnection();
        }

        public IConnection Connection
        {
            get
            {
                if (_connection != null)
                    return _connection;
                return _connection = _provider.ConnectionFactory.CreateConnection();
            }
        }

        private IModel _channel;
        public IModel Channel
        {
            get
            {
                if (_channel != null)
                    return _channel;
                else
                    return _channel = _connection.CreateModel();
            }
        }


        public void Dispose()
        {
            if (_channel != null)
            {
                _channel.Abort();
                if (_channel.IsOpen)
                    _channel.Close();

                _channel.Dispose();
            }

            if (_connection != null)
            {
                if (_connection.IsOpen)
                    _connection.Close();

                _connection.Dispose();
            }
        }

        /// <summary>
        /// 消费消息，并执行回调。
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="callback"></param>
        public void Subscribe(string channelName, Action<string> callback)
        {
            //声明交换机
            Channel.ExchangeDeclare(exchange: channelName, type: "direct");
            //消息队列名称
            var queueName = channelName;
            //声明队列
            Channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            //将队列与交换机进行绑定
            Channel.QueueBind(queue: queueName, exchange: channelName, routingKey: "web");
            //声明为手动确认，每次只消费1条消息。
            Channel.BasicQos(0, 1, false);
            //定义消费者
            var consumer = new EventingBasicConsumer(Channel);
            //接收事件
            consumer.Received += (eventSender, args) =>
            {
                var message = args.Body.Span;//接收到的消息

                callback(Encoding.UTF8.GetString(message));
                //返回消息确认
                Channel.BasicAck(args.DeliveryTag, true);
            };
            //开启监听
            Channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        }

        public Task<T> SubscribeAsync<T>(string channelName) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
