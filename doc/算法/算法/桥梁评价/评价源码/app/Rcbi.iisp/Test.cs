using Rcbi.iisp.Business;
using Rcbi.iisp.Business.ModelMsgEntity;
using Rcbi.iisp.Consumer.impl;
using Rcbi.iisp.Publisher.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.iisp
{

    public class Test
    {
        public void test()
        {
            List<string> queueName = new List<string>();
             queueName.Add("backen");
            var init = new InitializationTask();
            //init.init(queueName);

            Dictionary<string, Msg1> tasks = new Dictionary<string, Msg1>();
            var dtNow = DateTime.Now;
            //土建结构评估模型(TJEVA)
            tasks.Add("MQ_Tunnel_TJEVA", new Msg1()
            {
                TaskNO = "1-" + dtNow.ToString("yyyyMMddHHmmss"),
                DataSource_StartDate = dtNow.AddDays(-1),
                DataSource_EndDate = dtNow,
                ProjectID = "1",
                GenDate = dtNow
            });

            //// 路面性能评估模型（LMEVA）
            //queueName.Add("MQ_Tunnel_LMEVA");
            //// 机电设备评估模型（JDEVA）
            //queueName.Add("MQ_Tunnel_JDEVA");
            //// 附属设施评估模型（AFEVA）
            //queueName.Add("MQ_Tunnel_AFEVA");
            //// 运营服务评估模型（OSEVA）
            //queueName.Add("MQ_Tunnel_OSEVA");
            //// 运营成本估算模型
            //queueName.Add("MQ_Tunnel_FINEVA");
            //init.start(tasks);

            init.startENQ(tasks);
        }

    }
}
