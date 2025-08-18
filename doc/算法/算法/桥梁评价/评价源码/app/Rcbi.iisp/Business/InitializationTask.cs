using Newtonsoft.Json;
using Rcbi.iisp.Business.ModelMsgEntity;
using Rcbi.iisp.Business.ModelQueueBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.iisp.Business
{
    public class InitializationTask
    {
        private RabbitMqHelper rabbitMqHelper = new RabbitMqHelper();
        public InitializationTask init(Dictionary<string, Action<string>> Queues)
        {
            foreach (var queue in Queues)
            {
                rabbitMqHelper.Subscribe(queue.Key, queue.Value);
            }
            return this;
        }

        public void start(Dictionary<string, Msg1> tasks)
        {
            foreach (var task in tasks)
            {
                rabbitMqHelper.Publish(JsonConvert.SerializeObject(task.Value),task.Key);
            }
        }

        /// <summary>
        /// 指定队列发送1对1消息
        /// </summary>
        /// <param name="tasks"></param>
        public void startENQ(Dictionary<string, Msg1> tasks)
        {
            foreach (var task in tasks)
            {
                rabbitMqHelper.PublishENQ(JsonConvert.SerializeObject(task.Value), task.Key);
            }
        }

        /// <summary>
        /// 指定队列发送1对1消息
        /// </summary>
        /// <param name="tasks"></param>
        public void startENQ(Dictionary<string, Msg2> tasks)
        {
            foreach (var task in tasks)
            {
                rabbitMqHelper.PublishENQ(JsonConvert.SerializeObject(task.Value), task.Key);
            }
        }


    }
}
