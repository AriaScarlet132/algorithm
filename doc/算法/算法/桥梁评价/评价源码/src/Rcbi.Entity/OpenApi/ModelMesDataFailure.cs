using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的机电系统设备故障情况信息
    /// </summary>
    public class ModelMesDataFailure
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        [Required(ErrorMessage = "设备名称为必须")]
        public string EquipmentName { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        [Required(ErrorMessage = "设备编码为必须")]
        public string EquipmentCode { get; set; }

        /// <summary>
        /// 设备故障开始时间
        /// </summary>
        [Required(ErrorMessage = "设备故障开始时间为必须")]
        public DateTime BeginningFailure { get; set; }

        /// <summary>
        /// 设备故障结束时间
        /// </summary>
        public DateTime EndingFailure { get; set; }

        /// <summary>
        /// 累计故障时间
        /// </summary>
        [Required(ErrorMessage = "累计故障时间为必须")]
        public int TotalFailure { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必须")]
        public string TaskNo { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Column("datapushdate")]
        //public DateTime Datapushdate { get; set; }

    }
}