using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 沉降信息
    /// </summary>
    public class ModelTjDataSedimentation
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [Required(ErrorMessage = "开始日期为必须")]
        public DateTime? Start_Date { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Required(ErrorMessage = "结束日期为必须")]
        public DateTime End_Date { get; set; }

        /// <summary>
        /// 桩号
        /// </summary>
        [Required(ErrorMessage = "桩号为必须")]
        public string Station { get; set; }

        /// <summary>
        /// 编号-R
        /// </summary>
        public string Code_R { get; set; }

        /// <summary>
        /// 初始值-R
        /// </summary>
        public string Value_R { get; set; }

        /// <summary>
        /// 编号-L
        /// </summary>
        public string Code_L { get; set; }

        /// <summary>
        /// 初始值-L
        /// </summary>
        public string Value_L { get; set; }

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


        public string Code { get; set; }
        public decimal? Value { get; set; }
        public decimal? Sedimentation { get; set; }
    }
}