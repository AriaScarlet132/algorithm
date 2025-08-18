using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务用户服务类指标评价结果
    /// </summary>
    public class ModelOpResultCsi
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
        /// uci计算结果
        /// </summary>
        [Column("UCI_Value")]
        public decimal UciValue { get; set; }

        /// <summary>
        /// uci对应分值分数
        /// </summary>
        [Column("UCI_Score")]
        public decimal UciScore { get; set; }

        /// <summary>
        /// uci级别
        /// </summary>
        [Column("UCI_Level")]
        public decimal UciLevel { get; set; }

        /// <summary>
        /// uci等级描述
        /// </summary>
        [Column("UCI_Description")]
        public string UciDescription { get; set; }

        /// <summary>
        /// di日间计算结果
        /// </summary>
        [Column("DI_Day_Value")]
        public decimal DiDayValue { get; set; }

        /// <summary>
        /// di日间对应分值分数
        /// </summary>
        [Column("DI_Day_Score")]
        public decimal DiDayScore { get; set; }

        /// <summary>
        /// di日间级别
        /// </summary>
        [Column("DI_Day_Level")]
        public decimal DiDayLevel { get; set; }

        /// <summary>
        /// di日间等级描述
        /// </summary>
        [Column("DI_Day_Description")]
        public string DiDayDescription { get; set; }

        /// <summary>
        /// di夜间计算结果
        /// </summary>
        [Column("DI_Night_Value")]
        public decimal DiNightValue { get; set; }

        /// <summary>
        /// di夜间对应分值分数
        /// </summary>
        [Column("DI_Night_Score")]
        public decimal DiNightScore { get; set; }

        /// <summary>
        /// di夜间级别
        /// </summary>
        [Column("DI_Night_Level")]
        public decimal DiNightLevel { get; set; }

        /// <summary>
        /// di夜间等级描述
        /// </summary>
        [Column("DI_Night_Description")]
        public string DiNightDescription { get; set; }

        /// <summary>
        /// bi计算结果
        /// </summary>
        [Column("BI_Value")]
        public decimal BiValue { get; set; }

        /// <summary>
        /// bi对应分值分数
        /// </summary>
        [Column("BI_Score")]
        public decimal BiScore { get; set; }

        /// <summary>
        /// bi级别
        /// </summary>
        [Column("BI_Level")]
        public decimal BiLevel { get; set; }

        /// <summary>
        /// bi等级描述
        /// </summary>
        [Column("BI_Description")]
        public string BiDescription { get; set; }

        /// <summary>
        /// uvci计算结果
        /// </summary>
        [Column("UCVI_Value")]
        public decimal UvciValue { get; set; }

        /// <summary>
        /// uvci对应分值分数
        /// </summary>
        [Column("UCVI_Score")]
        public decimal UvciScore { get; set; }

        /// <summary>
        /// uvci级别
        /// </summary>
        [Column("UCVI_Level")]
        public decimal UvciLevel { get; set; }

        /// <summary>
        /// uvci等级描述
        /// </summary>
        [Column("UCVI_Description")]
        public string UvciDescription { get; set; }

     
    }
}