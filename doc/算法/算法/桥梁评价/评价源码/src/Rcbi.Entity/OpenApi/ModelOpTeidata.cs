using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 交牵引排堵TEI业务信息
    /// </summary>
    public class ModelOpTeidata
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
        /// m1次数
        /// </summary>
        [Required(ErrorMessage = "m1次数（（事故通知时间-牵引车启动时间）<=2分钟）为必输")]
        public int M1amount { get; set; }

        /// <summary>
        /// m2次数
        /// </summary>
        [Required(ErrorMessage = "m2次数（（牵引车启动时间-牵引车到达牵引地点时间）<=20分钟）为必输")]
        public int M2amount { get; set; }

        /// <summary>
        /// 当日牵引总次数
        /// </summary>
        [Required(ErrorMessage = "当日牵引总次数为必输")]
        public int Totalinday { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}