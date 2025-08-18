using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 用户满意度UCVI业务信息
    /// </summary>
    public class ModelOpUcvidata
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
        /// 年份
        /// </summary>
        [Required(ErrorMessage = "年份为必输")]
        public string DataYear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        [Required(ErrorMessage = "月份为必输")]
        public string DataMonth { get; set; }

        /// <summary>
        /// n（来信、来访、来电未及时处置数）
        /// </summary>
        [Required(ErrorMessage = "n（来信、来访、来电未及时处置数）为必输")]
        public string DelayAmount { get; set; }

        /// <summary>
        /// n（来信、来访、来电应处置数）
        /// </summary>
        [Required(ErrorMessage = "n（来信、来访、来电应处置数）为必输")]
        public decimal HandleAmount { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}