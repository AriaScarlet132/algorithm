using Newtonsoft.Json;
using Rcbi.AspNetCore.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.iisp.Business.ModelMsgEntity
{
    public class Msg1
    {
        //任务号
        public string TaskNO { get; set; }
        //计算用数据源开始时间
        [JsonConverter(typeof(DateFormat))]
        public DateTime DataSource_StartDate { get; set; }
        //计算用数据源结束时间
        [JsonConverter(typeof(DateFormat))]
        public DateTime DataSource_EndDate { get; set; }
        //项目ID
        public string ProjectID { get; set; }
        //模型配置
        public string ConfigID { get; set; }
        //消息发送时间
        [JsonConverter(typeof(DateFormat))]
        public DateTime GenDate { get; set; }
        //模型类型
        public string Model_Type { get; set; }
        //设施类型
        public string Facility_Type { get;set; }
    }

    public class Msg2
    {
        //任务号
        public string MainTaskNo { get; set; }

        //项目ID
        public SubTaskModel SubTaskNo { get; set; }
        
    }

    public class SubTaskModel
    {
        //任务号
        //public string tjzq_taskno { get; set; }
        public string[] tjzq_taskno { get; set; }
        public string[] tjyq_taskno { get; set; }
        public string jd_taskno { get; set; }
        public string af_taskno { get; set; }
        public string os_taskno { get; set; }

    }

}
