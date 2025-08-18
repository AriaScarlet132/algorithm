using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 内业管理服务指标评价等级
    /// </summary>
    public class ModelOpMsiCriteria
    {
        /// <summary>
        /// 等级下限
        /// </summary>
        [Required(ErrorMessage = "等级下限为必输")]
        public int MinValue { get; set; }

        /// <summary>
        /// 等级上限
        /// </summary>
        [Required(ErrorMessage = "等级上限为必输")]
        public int MaxValue { get; set; }

        /// <summary>
        /// 等级名称
        /// </summary>
        [Required(ErrorMessage = "等级名称为必输")]
        public string LevelName { get; set; }

        /// <summary>
        /// 等级值
        /// </summary>
        [Required(ErrorMessage = "等级值为必输")]
        public int LevelValue { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string ProjectCode { get; set; }
    }
}