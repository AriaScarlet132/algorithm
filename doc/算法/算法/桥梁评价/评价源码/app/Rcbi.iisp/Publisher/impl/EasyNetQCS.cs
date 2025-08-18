using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rcbi.Core;

namespace Rcbi.Iisp.Publisher.impl
{
    public class EasyNetQCS
    {
        ///// <summary>
        ///// 链接配置
        ///// </summary>
        //private static string connStr = "host=121.41.10.16:5672;username=rabbit_tbmp;password=rabbit_tbmp";

        /// <summary>
        /// 创建总线
        /// </summary>
        /// <param name="connStr">配置</param>
        /// <returns></returns>
        public static IBus CreateBus(string connStr) {
            return RabbitHutch.CreateBus(connStr);   
        }

    }
}
