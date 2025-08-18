using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务安全服务类指标评价结果
    /// </summary>
    public class ModelOpResultSsi
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
        /// Rv计算结果
        /// </summary>
        [Column("RV_Value")]
        public decimal RvValue { get; set; }

        /// <summary>
        /// Rv对应分值分数
        /// </summary>
        [Column("RV_Score")]
        public decimal RvScore { get; set; }

        /// <summary>
        /// Rv级别
        /// </summary>
        [Column("RV_Level")]
        public decimal RvLevel { get; set; }

        /// <summary>
        /// Rv等级描述
        /// </summary>
        [Column("RV_Description")]
        public string RvDescription { get; set; }

        /// <summary>
        /// VI计算结果
        /// </summary>
        [Column("VI_Value")]
        public decimal ViValue { get; set; }

        /// <summary>
        /// VI对应分值分数
        /// </summary>
        [Column("VI_Score")]
        public decimal ViScore { get; set; }

        /// <summary>
        /// VI级别
        /// </summary>
        [Column("VI_Level")]
        public decimal ViLevel { get; set; }

        /// <summary>
        /// VI等级描述
        /// </summary>
        [Column("VI_Description")]
        public string ViDescription { get; set; }

        /// <summary>
        /// CO计算结果
        /// </summary>
        [Column("CO_Value")]
        public decimal CoValue { get; set; }

        /// <summary>
        /// CO对应分值分数
        /// </summary>
        [Column("CO_Score")]
        public decimal CoScore { get; set; }

        /// <summary>
        /// CO级别
        /// </summary>
        [Column("CO_Level")]
        public decimal CoLevel { get; set; }

        /// <summary>
        /// CO等级描述
        /// </summary>
        [Column("CO_Description")]
        public string CoDescription { get; set; }

        /// <summary>
        /// PM计算结果
        /// </summary>
        [Column("PM_Value")]
        public decimal PmValue { get; set; }

        /// <summary>
        /// PM对应分值分数
        /// </summary>
        [Column("PM_Score")]
        public decimal PmScore { get; set; }

        /// <summary>
        /// PM级别
        /// </summary>
        [Column("PM_Level")]
        public decimal PmLevel { get; set; }

        /// <summary>
        /// PM等级描述
        /// </summary>
        [Column("PM_Description")]
        public string PmDescription { get; set; }

       

     
    }
}