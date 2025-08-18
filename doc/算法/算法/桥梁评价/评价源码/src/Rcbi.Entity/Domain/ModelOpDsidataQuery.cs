using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 行驶速率DSI业务信息
    /// </summary>
    public class ModelOpDsidataQuery : LayuiQuery
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
        /// l观测隧道路段公路长度（km)
        /// </summary>
        public decimal MonitorLength { get; set; }

        /// <summary>
        /// t第i观测车通过该路段的行程时间（小时）
        /// </summary>
        public decimal PassTime { get; set; }

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