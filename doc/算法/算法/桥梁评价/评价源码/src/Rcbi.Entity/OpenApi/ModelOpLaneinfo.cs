using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    ///隧道车道基本业务信息
    /// </summary>
    public class ModelOpLaneinfo
    {
        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必输")]
        public string LineCode { get; set; }

        /// <summary>
        /// 车道号
        /// </summary>
        [Required(ErrorMessage = "车道号为必输")]
        public string LaneCode { get; set; }

        /// <summary>
        /// 车道宽度
        /// </summary>
        [Required(ErrorMessage = "车道宽度为必输")]
        public decimal LaneWidth { get; set; }

        /// <summary>
        /// 车道长度
        /// </summary>
        [Required(ErrorMessage = "车道长度为必输")]
        public decimal LaneLength { get; set; }

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
    }
}