using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 内业成本绩效MCI业务信息
    /// </summary>
    public class ModelOpMcidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 实际成本
        /// </summary>
        public decimal RealCost { get; set; }

        /// <summary>
        /// 实际性能
        /// </summary>
        public decimal RealPerformance { get; set; }

        /// <summary>
        /// 实际成本数据生成时间
        /// </summary>
        public DateTime RealDate { get; set; }

        /// <summary>
        /// 计划成本
        /// </summary>
        public decimal PlanCost { get; set; }

        /// <summary>
        /// 计划性能
        /// </summary>
        public decimal PlanPerformance { get; set; }

        /// <summary>
        /// 计算成本数据生成时间
        /// </summary>
        public DateTime PlanDate { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }


        /// <summary>
        /// 年度
        /// </summary>
        public string DocYear { get; set; }

        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}