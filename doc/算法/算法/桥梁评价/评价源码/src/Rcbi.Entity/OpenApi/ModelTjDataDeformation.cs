using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 收敛变形信息
    /// </summary>
    public class ModelTjDataDeformation
    {
        /// <summary>
        /// 日期
        /// </summary>
        [Required(ErrorMessage = "时间为必须")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// 测点编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 里程号
        /// </summary>
        [Required(ErrorMessage = "里程号为必须")]
        public string Station { get; set; }

        /// <summary>
        /// 变量
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 变量编号
        /// </summary>
        public string ValueCode { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "检测值为必须")]
        public decimal? DeformationValue { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public decimal? Value { get; set; }

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
        ///// 直径变化量
        ///// </summary>
        //public decimal? deformationValue { get; set; }
    }
}