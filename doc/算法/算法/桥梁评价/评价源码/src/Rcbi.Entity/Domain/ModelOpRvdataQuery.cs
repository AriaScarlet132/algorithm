using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 安全事故率RV业务信息
    /// </summary>
    public class ModelOpRvdataQuery : LayuiQuery
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
        /// 年份
        /// </summary>
        public int MonitorYear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public int MonitorMonth { get; set; }

        /// <summary>
        /// 事故数
        /// </summary>
        public int Accident_Num { get; set; }

        /// <summary>
        /// 抛锚数
        /// </summary>
        public int Broke_Down { get; set; }

        /// <summary>
        /// 平均日流量
        /// </summary>
        public decimal Average_Stream { get; set; }

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