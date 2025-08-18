using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 交牵引排堵TEI业务信息
    /// </summary>
    public class ModelOpTeidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 观测日期
        /// </summary>
        public DateTime MonitorDate { get; set; }

        /// <summary>
        /// m1次数（（事故通知时间-牵引车启动时间）<=2分钟）
        /// </summary>
        public int M1amount { get; set; }

        /// <summary>
        /// m2次数（（牵引车启动时间-牵引车到达牵引地点时间）<=20分钟）
        /// </summary>
        public int M2amount { get; set; }

        /// <summary>
        /// 当日牵引总次数
        /// </summary>
        public int Totalinday { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}