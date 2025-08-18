using Rcbi.Core;
using Rcbi.iisp.Business.ModelMsgEntity;
using Rcbi.iisp.Consumer.impl;
using Rcbi.iisp.Publisher.impl;
using Rcbi.Iisp.Publisher.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rcbi.AspNetCore.Helper;
namespace Rcbi.iisp
{
    public class RabbitMqHelper
    {
        private readonly RabbitMQProvider _provider;
        private readonly RabbitMQPublisher _publisher;
        private readonly RabbitMQSubscriber _subscriber;
        public RabbitMqHelper()
        {
            string ip = ConfigHelper.GetConfig("RabbitMqConnection.IP");
            int port = Convert.ToInt32(ConfigHelper.GetConfig("RabbitMqConnection.Port"));
            string username = ConfigHelper.GetConfig("RabbitMqConnection.UserName");
            string password = ConfigHelper.GetConfig("RabbitMqConnection.PassWord");
            _provider = new RabbitMQProvider(ip, port, username, password);
            _publisher = new RabbitMQPublisher(_provider);
            _subscriber = new RabbitMQSubscriber(_provider);
        }

  

        public void Publish(string msg, string QueueNames)
        {
            _publisher.Publish(msg, QueueNames);
        }

        public void Subscribe(string QueueNames, Action<string> callback)
        {
            _subscriber.Subscribe(QueueNames, callback);
        }

        public string getMsg(string msg)
        {
            return msg;
        }

        /// <summary>
        /// 指定队列发送1对1消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="QueueNames">线程名称</param>

        public async void PublishENQ(string msg, string QueueNames) {
            string ip = ConfigHelper.GetConfig("RabbitMqConnection.IP");  //ip地址
            int port = Convert.ToInt32(ConfigHelper.GetConfig("RabbitMqConnection.Port"));//端口号
            string username = ConfigHelper.GetConfig("RabbitMqConnection.UserName"); //账号  
            string password = ConfigHelper.GetConfig("RabbitMqConnection.PassWord"); //密码
            string connStr = "host={0}:{1};username={2};password={3}";
            connStr = string.Format(connStr, ip, port, username, password);
            using (var bus = EasyNetQCS.CreateBus(connStr))
            {
                await bus.SendAsync(QueueNames, msg);
            }
        }

        //public void SubscribeENQ(string QueueNames, Action<string> callback)
        //{
        //    using (var bus = EasyNetQCS.CreateBus())
        //    {
        //        bus.Receive("web", async r =>
        //        {
        //            await Task.Run(() =>
        //            {
        //                // Console.WriteLine("Receive:" + r.Text);
        //                LogHelper.Info(r.ToString());
        //            });
        //        });
        //    }
        //}

    }
}
