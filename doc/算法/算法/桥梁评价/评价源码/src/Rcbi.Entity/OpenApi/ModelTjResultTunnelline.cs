using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的线路级评价结果
    /// </summary>
    public class ModelTjResultTunnelline
    {
        /// <summary>
        /// 线路
        /// </summary>
        public string Line { get; set; }

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
        /// 任务号
        /// </summary>
        public string Task_No { get; set; }
    }
}