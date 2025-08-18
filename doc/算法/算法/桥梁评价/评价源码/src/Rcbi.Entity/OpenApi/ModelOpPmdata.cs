using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 可吸入颗粒物浓度PM2.5业务信息
    /// </summary>
    public class ModelOpPmdata
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
        /// 安装位置
        /// </summary>
        [Required(ErrorMessage = "安装位置为必输")]
        public string Position { get; set; }

        /// <summary>
        /// 里程桩号
        /// </summary>
        [Required(ErrorMessage = "里程桩号为必输")]
        public string Mileage { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        [Required(ErrorMessage = "设备编号为必输")]
        public string DeviceNo { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        [Required(ErrorMessage = "年份为必输")]
        public string MonitorYear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        [Required(ErrorMessage = "月份为必输")]
        public string MonitorMonth { get; set; }

        /// <summary>
        /// 检测值
        /// </summary>
        [Required(ErrorMessage = "检测值为必输")]
        public decimal MonitorData { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}