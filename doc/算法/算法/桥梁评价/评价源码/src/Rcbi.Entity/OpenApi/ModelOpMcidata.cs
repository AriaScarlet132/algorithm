using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 内业成本绩效MCI业务信息
    /// </summary>
    public class ModelOpMcidata
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
        /// 月份
        /// </summary>
        [Required(ErrorMessage = "月份为必输")]
        public int Month { get; set; }

        /// <summary>
        /// 实际成本
        /// </summary>
        [Required(ErrorMessage = "实际成本为必输")]
        public decimal RealCost { get; set; }

        /// <summary>
        /// 实际性能
        /// </summary>
        [Required(ErrorMessage = "实际性能为必输")]
        public decimal RealPerformance { get; set; }

        /// <summary>
        /// 实际成本数据生成时间
        /// </summary>
        [Required(ErrorMessage = "实际成本数据生成时间为必输")]
        public DateTime RealDate { get; set; }

        /// <summary>
        /// 计划成本
        /// </summary>
        [Required(ErrorMessage = "计划成本为必输")]
        public decimal PlanCost { get; set; }

        /// <summary>
        /// 计划性能
        /// </summary>
        [Required(ErrorMessage = "计划性能为必输")]
        public decimal PlanPerformance { get; set; }

        /// <summary>
        /// 计算成本数据生成时间
        /// </summary>
        [Required(ErrorMessage = "计算成本数据生成时间为必输")]
        public DateTime PlanDate { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [Required(ErrorMessage = "年度为必输")]
        public string DocYear { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}