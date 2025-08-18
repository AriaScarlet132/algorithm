using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    ///  运营服务分类项目评价结果
    /// </summary>
    public class ModelOpResultClassification
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        [Column("Start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("End")]
        public DateTime End { get; set; }

        /// <summary>
        /// tsi计算结果
        /// </summary>
        [Column("TSI_Value")]
        public decimal TsiValue { get; set; }

        /// <summary>
        /// tsi级别
        /// </summary>
        [Column("TSI_Level")]
        public decimal TsiLevel { get; set; }

        /// <summary>
        /// ssi计算结果
        /// </summary>
        [Column("SSI_Value")]
        public decimal SsiValue { get; set; }

        /// <summary>
        /// ssi级别
        /// </summary>
        [Column("SSI_Level")]
        public decimal SsiLevel { get; set; }

        /// <summary>
        /// csi计算结果
        /// </summary>
        [Column("CSI_Value")]
        public decimal CsiValue { get; set; }

        /// <summary>
        /// csi级别
        /// </summary>
        [Column("CSI_Level")]
        public decimal CsiLevel { get; set; }

        /// <summary>
        /// msi级别
        /// </summary>
        [Column("MSI_Value")]
        public decimal MsiValue { get; set; }

        /// <summary>
        /// ms级别
        /// </summary>
        [Column("MSI_Level")]
        public decimal MsiLevel { get; set; }
    }
}