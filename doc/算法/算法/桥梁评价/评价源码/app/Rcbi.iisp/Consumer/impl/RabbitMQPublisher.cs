using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.iisp.Consumer.impl
{
    /// <summary>
    /// 消息发布者。
    /// </summary>
    public class RabbitMQPublisher : IPublisher
    {

        private readonly RabbitMQProvider _provider;
        private IConnection _connection;
        public RabbitMQPublisher(RabbitMQProvider provider)
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
            if (Channel != null)
            {
                if (Channel.IsOpen)
                    Channel.Close();
                Channel.Abort();
                Channel.Dispose();
            }

            if (Connection != null)
            {
                if (Connection.IsOpen)
                    Connection.Close();
            }
        }

        public void Publish<T>(T message) where T : class
        {
            var channelName = typeof(T).Name;
            Channel.ExchangeDeclare(channelName, "fanout", false, false, null);

            var msgContent = JsonConvert.SerializeObject(message);
            var msgByte = Encoding.UTF8.GetBytes(msgContent);
            Channel.BasicPublish
            (
                exchange: channelName,
                routingKey: string.Empty,
                mandatory: false,
                basicProperties: null,
                body: msgByte
            );
        }


        public void Publish(string message, string channelName)
        {
            Channel.ExchangeDeclare(channelName, "direct",  false,  false, null);

            var msgByte = Encoding.UTF8.GetBytes(message);
            Channel.BasicPublish
            (
                exchange: channelName,
                routingKey: "backen",
                mandatory: false,
                basicProperties: null,
                body: msgByte
            );
        }

        public Task PublishAsync<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
