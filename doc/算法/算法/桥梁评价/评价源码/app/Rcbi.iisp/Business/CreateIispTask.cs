using Newtonsoft.Json;
using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Domain;
using Rcbi.Entity.OpenApi;
using Rcbi.iisp.Business.ModelMsgEntity;
using Rcbi.iisp.Business.ModelQueueBusiness;
using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Rcbi.iisp.Business
{
    public class CreateIispTask
    {
        static Dictionary<string, Action<string>> queue = new Dictionary<string, Action<string>>();
        static Dictionary<string, Msg1> tasks = new Dictionary<string, Msg1>();
        static Dictionary<string, Msg2> tasks2 = new Dictionary<string, Msg2>();
        static InitializationTask init = new InitializationTask();


        public static void Send(TbModelResultMain model)
        {
            //queue send
            tasks = new Dictionary<string, Msg1>();
            Msg1 msg1 = new Msg1()
            {
                TaskNO = model.taskno,
                DataSource_StartDate = model.datasource_startdate,
                DataSource_EndDate = model.datasource_enddate,
                ProjectID = model.projectid,
                GenDate = DateTime.Now,
                Model_Type = model.model_type,
                Facility_Type = model.facility_type
            };
            tasks.Add("MQ_" + model.facility_type + "_" + model.model_type, msg1);
            LogHelper.TaskInfo(model.taskno, model.model_type, "分析数据推送", JsonConvert.SerializeObject(msg1));
            //原方法
            //init.start(tasks);
            init.startENQ(tasks);
        }
        public static void Send(TbModelResultMain model,string vison)
        {
            //queue send
            tasks = new Dictionary<string, Msg1>();
            Msg1 msg1 = new Msg1()
            {
                TaskNO = model.taskno,
                DataSource_StartDate = model.datasource_startdate,
                DataSource_EndDate = model.datasource_enddate,
                ProjectID = model.projectid,
                GenDate = DateTime.Now,
                Model_Type = model.model_type,
                Facility_Type = model.facility_type
            };
            tasks.Add("MQ_" + model.facility_type + "_" + model.model_type+"_"+ vison, msg1);
            LogHelper.TaskInfo(model.taskno, model.model_type, "分析数据推送", JsonConvert.SerializeObject(msg1));
            //原方法
            //init.start(tasks);
            init.startENQ(tasks);
        }

        /// <summary>
        /// 添加总体评价任务的消息队列
        /// </summary>
        /// <param name="model"></param>
        /// <param name="MainTaskNo"></param>

        public static void SendOverallEvaluationTask(OverallEvaluation model,string MainTaskNo)
        {
            //queue send
            tasks2 = new Dictionary<string, Msg2>();
            Msg2 msg2 = new Msg2()
            {
                MainTaskNo = MainTaskNo,
                SubTaskNo = new SubTaskModel
                {
                    tjzq_taskno = model.tjzq_taskno,
                    tjyq_taskno = model.tjyq_taskno,
                    af_taskno = model.af_taskno,
                    os_taskno = model.os_taskno,
                    jd_taskno = model.jd_taskno
                }
            };
            tasks2.Add("MQ_" + model.facility_type + "_ALL", msg2);
            LogHelper.TaskInfo(MainTaskNo, model.facility_type, "添加总体评价任务", JsonConvert.SerializeObject(msg2));
            //原方法
            //init.start(tasks);
            init.startENQ(tasks2);
        }

        /// <summary>
        /// 启动监听 空方法初始化静态区
        /// </summary>
        public static void StartSubscribe()
        {
            //queue listen
            queue = new Dictionary<string, Action<string>>();
            queue.Add("web", a => MQ_Tunnel_Business.Execute(a));
            init.init(queue);
        }
    }
}
