using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 交通畅通率DFR业务信息
    /// </summary>
    public class ModelOpDfrdata
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
        /// 观测日期
        /// </summary>
        [Required(ErrorMessage = "观测日期为必输")]
        public DateTime MonitorDate { get; set; }

        /// <summary>
        /// 日受阻时间（小时）
        /// </summary>
        [Required(ErrorMessage = "日受阻时间（小时）为必输")]
        public decimal DelayTimes { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}