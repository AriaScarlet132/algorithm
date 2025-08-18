using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的机电系统设备运行情况信息
    /// </summary>
    public class ModelMesDataOperation
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
        /// 设备运行开始时间
        /// </summary>
        [Required(ErrorMessage = "设备运行开始时间为必须")]
        public DateTime BeginningOperation { get; set; }

        /// <summary>
        /// 设备运行结束时间
        /// </summary>
        [Required(ErrorMessage = "设备运行结束时间为必须")]
        public DateTime EndingOperation { get; set; }

        /// <summary>
        /// 累计运行时间
        /// </summary>
        [Required(ErrorMessage = "累计运行时间为必须")]
        public int TotalOperation { get; set; }

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