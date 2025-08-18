using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务交通服务类指标评价结果
    /// </summary>
    public class ModelOpResultTsi
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

        [Column("DTI_Value")]
        public string DtiValue { get; set; }


        [Column("DTI_Score")]
        public string DtiScore { get; set; }

        /// <summary>
        /// dti等级描述
        /// </summary>
        [Column("DTI_Description")]
        public string DtiDescription { get; set; }

        /// <summary>
        /// dsi计算结果
        /// </summary>
        [Column("DSI_Value")]
        public decimal DsiValue { get; set; }

        /// <summary>
        /// dsi对应分值分数
        /// </summary>
        [Column("DSI_Score")]
        public decimal DsiScore { get; set; }

        /// <summary>
        /// dsi级别
        /// </summary>
        [Column("DSI_Level")]
        public decimal DsiLevel { get; set; }

        /// <summary>
        /// dsi等级描述
        /// </summary>
        [Column("DSI_Description")]
        public string DsiDescription { get; set; }

        /// <summary>
        /// dfr计算结果
        /// </summary>
        [Column("DFR_Value")]
        public decimal DfrValue { get; set; }

        /// <summary>
        /// dfr对应分值分数
        /// </summary>
        [Column("DFR_Score")]
        public decimal DfrScore { get; set; }

        /// <summary>
        /// dfr级别
        /// </summary>
        [Column("DFR_Level")]
        public decimal DfrLevel { get; set; }

        /// <summary>
        /// dfr等级描述
        /// </summary>
        [Column("DFR_Description")]
        public string DfrDescription { get; set; }

        /// <summary>
        /// tei计算结果
        /// </summary>
        [Column("TEI_Value")]
        public decimal TeiValue { get; set; }

        /// <summary>
        /// tei对应分值分数
        /// </summary>
        [Column("TEI_Score")]
        public decimal TeiScore { get; set; }

        /// <summary>
        /// tei级别
        /// </summary>
        [Column("TEI_Level")]
        public decimal TeiLevel { get; set; }

        /// <summary>
        /// tei等级描述
        /// </summary>
        [Column("TEI_Description")]
        public string TeiDescription { get; set; }

        /// <summary>
        /// lr计算结果
        /// </summary>
        [Column("LR_Value")]
        public decimal LrValue { get; set; }

        /// <summary>
        /// lr对应分值分数
        /// </summary>
        [Column("LR_Score")]
        public decimal LrScore { get; set; }

        /// <summary>
        /// lr级别
        /// </summary>
        [Column("LR_Level")]
        public decimal LrLevel { get; set; }

        /// <summary>
        /// lr等级描述
        /// </summary>
        [Column("LR_Description")]
        public string LrDescription { get; set; }

       
    }
}