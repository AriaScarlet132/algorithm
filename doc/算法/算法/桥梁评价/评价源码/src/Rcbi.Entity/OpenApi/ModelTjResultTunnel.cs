using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的土建结构评价结果
    /// </summary>
    public class ModelTjResultTunnel
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// 评价得分
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 评价等级
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }
    }
}