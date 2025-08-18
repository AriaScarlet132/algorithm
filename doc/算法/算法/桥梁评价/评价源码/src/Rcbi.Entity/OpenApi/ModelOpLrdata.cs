using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 交通路面荷载LR业务信息
    /// </summary>
    public class ModelOpLrdata
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
        /// 车辆数
        /// </summary>
        [Required(ErrorMessage = "车辆数为必输")]
        public int TotalCar { get; set; }

        /// <summary>
        /// 小型车数
        /// </summary>
        [Required(ErrorMessage = "小型车数为必输")]
        public int SmallCarAmount { get; set; }

        /// <summary>
        /// 大型车数
        /// </summary>
        [Required(ErrorMessage = "大型车数为必输")]
        public int BigCarAmount { get; set; }

        /// <summary>
        /// 中型车数
        /// </summary>
        [Required(ErrorMessage = "中型车数为必输")]
        public int MediumCarAmount { get; set; }

        /// <summary>
        /// 集卡数
        /// </summary>
        [Required(ErrorMessage = "集卡数为必输")]
        public int TruckAmount { get; set; }

        /// <summary>
        /// 客车1数
        /// </summary>
        [Required(ErrorMessage = "客车1数为必输")]
        public int BusAmount1 { get; set; }

        /// <summary>
        /// 客车2数
        /// </summary>
        [Required(ErrorMessage = "客车2数为必输")]
        public int BusAmount2 { get; set; }

        /// <summary>
        /// 客车3数
        /// </summary>
        [Required(ErrorMessage = "客车3数为必输")]
        public int BusAmount3 { get; set; }

        /// <summary>
        /// 客车4数
        /// </summary>
        [Required(ErrorMessage = "客车4数为必输")]
        public int BusAmount4 { get; set; }

        /// <summary>
        /// 货车1数
        /// </summary>
        [Required(ErrorMessage = "货车1数为必输")]
        public int VanAmount1 { get; set; }

        /// <summary>
        /// 货车2数
        /// </summary>
        [Required(ErrorMessage = "货车2数为必输")]
        public int VanAmount2 { get; set; }

        /// <summary>
        /// 货车3数
        /// </summary>
        [Required(ErrorMessage = "货车3数为必输")]
        public int VanAmount3 { get; set; }

        /// <summary>
        /// 货车4数
        /// </summary>
        [Required(ErrorMessage = "货车4数为必输")]
        public int VanAmount4 { get; set; }

        /// <summary>
        /// 货车5数
        /// </summary>
        [Required(ErrorMessage = "货车5数为必输")]
        public int VanAmount5 { get; set; }

        /// <summary>
        /// 集卡1数
        /// </summary>
        [Required(ErrorMessage = "集卡1数为必输")]
        public int TruckAmount1 { get; set; }

        /// <summary>
        /// 集卡2数
        /// </summary>
        [Required(ErrorMessage = "集卡2数为必输")]
        public int TruckAmount2 { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}