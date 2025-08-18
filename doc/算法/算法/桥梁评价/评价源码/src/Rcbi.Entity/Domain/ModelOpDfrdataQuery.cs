using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 交通畅通率DFR业务信息
    /// </summary>
    public class ModelOpDfrdataQuery : LayuiQuery
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
        /// 日受阻时间（小时）
        /// </summary>
        public decimal DelayTimes { get; set; }

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