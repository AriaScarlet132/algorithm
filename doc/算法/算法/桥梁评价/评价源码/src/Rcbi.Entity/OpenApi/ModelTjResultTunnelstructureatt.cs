using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的结构属性级评价结果
    /// </summary>
    public class ModelTjResultTunnelstructureatt
    {
        /// <summary>
        /// 线路
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// 结构属性
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// 评价得分
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 评价等级
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }
    }
}