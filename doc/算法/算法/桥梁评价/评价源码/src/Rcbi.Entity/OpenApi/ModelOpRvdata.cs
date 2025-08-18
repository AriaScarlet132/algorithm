using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 安全事故率RV业务信息
    /// </summary>
    public class ModelOpRvdata
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必输")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必输")]
        public string LineCode { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        [Required(ErrorMessage = "年份为必输")]
        public int MonitorYear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        [Required(ErrorMessage = "月份为必输")]
        public int MonitorMonth { get; set; }

        /// <summary>
        /// 事故数
        /// </summary>
        [Required(ErrorMessage = "事故数为必输")]
        public int AccidentNum { get; set; }

        /// <summary>
        /// 抛锚数
        /// </summary>
        [Required(ErrorMessage = "抛锚数为必输")]
        public int BrokeDown { get; set; }

        /// <summary>
        /// 平均日流量
        /// </summary>
        [Required(ErrorMessage = "平均日流量为必输")]
        public decimal AverageStream { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}