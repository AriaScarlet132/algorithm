using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务内业管理类指标评价结果
    /// </summary>
    public class ModelOpResultMsi
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

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
        /// mbi计算结果
        /// </summary>
        [Column("MBI_Value")]
        public decimal MbiValue { get; set; }

        /// <summary>
        /// mbi对应分值分数
        /// </summary>
        [Column("MBI_Score")]
        public decimal MbiScore { get; set; }

        /// <summary>
        /// mbi级别
        /// </summary>
        [Column("MBI_Level")]
        public decimal MbiLevel { get; set; }

        /// <summary>
        /// mbi等级描述
        /// </summary>
        [Column("MBI_Description")]
        public string MbiDescription { get; set; }

        /// <summary>
        /// mssi计算结果
        /// </summary>
        [Column("MSSI_Value")]
        public decimal MssiValue { get; set; }

        /// <summary>
        /// mssi对应分值分数
        /// </summary>
        [Column("MSSI_Score")]
        public decimal MssiScore { get; set; }

        /// <summary>
        /// mssi级别
        /// </summary>
        [Column("MSSI_Level")]
        public decimal MssiLevel { get; set; }

        /// <summary>
        /// mssi等级描述
        /// </summary>
        [Column("MSSI_Description")]
        public string MssiDescription { get; set; }

        /// <summary>
        /// mii计算结果
        /// </summary>
        [Column("MII_Value")]
        public decimal MiiValue { get; set; }

        /// <summary>
        /// mii对应分值分数
        /// </summary>
        [Column("MII_Score")]
        public decimal MiiScore { get; set; }

        /// <summary>
        /// mii级别
        /// </summary>
        [Column("MII_Level")]
        public decimal MiiLevel { get; set; }

        /// <summary>
        /// mii等级描述
        /// </summary>
        [Column("MII_Description")]
        public string MiiDescription { get; set; }

        /// <summary>
        /// mci计算结果
        /// </summary>
        [Column("MCI_Value")]
        public decimal MciValue { get; set; }

        /// <summary>
        /// mci对应分值分数
        /// </summary>
        [Column("MCI_Score")]
        public decimal MciScore { get; set; }

        /// <summary>
        /// mci级别
        /// </summary>
        [Column("MCI_Level")]
        public decimal MciLevel { get; set; }

        /// <summary>
        /// mci等级描述
        /// </summary>
        [Column("MCI_Description")]
        public string MciDescription { get; set; }

       
    }
}