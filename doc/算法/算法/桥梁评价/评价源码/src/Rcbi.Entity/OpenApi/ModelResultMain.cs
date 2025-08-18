using System;
namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 任务结果表
    /// </summary>
    public class ModelResultMain
    {

        /// <summary>
        /// 流水号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        private string ProjectID { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskNO { get; set; }  
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime DataSource_StartDate { get; set; } 
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime DataSource_EndDate { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_code { get { return ProjectID; } set { } }
        /// <summary>
        /// 模型类型
        /// </summary>
        public string Model_Type { get; set; }
        /// <summary>
        /// 模型执行状态
        /// </summary>
        public string ModelStatus { get; set; }
        /// <summary>
        /// 消息发生时间
        /// </summary>
        public DateTime MsgDate { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 给服务回掉接口
        /// </summary>
        public string Callback_Url { get; set; }
        /// <summary>
        /// 数据更新对象
        /// </summary>
        public string DataInserter { get; set; }
        /// <summary>
        /// 数据插入时间
        /// </summary>
        public DateTime DataInsertTime { get; set; }
        /// <summary>
        /// 模型计算的配置
        /// </summary>
        public string ConfigID { get; set; } 
        /// <summary>
        /// 设施类型
        /// </summary>
        public string Facility_Type { get; set; }

    }
}

