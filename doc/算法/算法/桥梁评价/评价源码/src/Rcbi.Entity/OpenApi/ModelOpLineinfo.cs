using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    ///  隧道线路基本业务信息
    /// </summary>
    public class ModelOpLineinfo
    {
        /// <summary>
        /// 线路名称
        /// </summary>
        [Required(ErrorMessage = "线路名称为必输")]
        public string LineName { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必输")]
        public string LineCode { get; set; }

        /// <summary>
        /// 线路长度
        /// </summary>
        [Required(ErrorMessage = "线路长度为必输")]
        public decimal LineLength { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(ErrorMessage = "项目名称为必输")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必输")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注为必输")]
        public string Memo { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }

        public string StructureType { get; set; }

        public int StructureTypeLength { get; set; }
    }
}