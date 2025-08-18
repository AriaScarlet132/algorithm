using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 用户舒适度UCI业务信息
    /// </summary>
    public class ModelOpUcidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 调查日期
        /// </summary>
        public DateTime InvestDate { get; set; }

        /// <summary>
        /// 调查内容
        /// </summary>
        public string InvestContent { get; set; }

        /// <summary>
        /// 客户年龄
        /// </summary>
        public string CustomerAge { get; set; }

        /// <summary>
        /// 客户性别
        /// </summary>
        public string CustomerSex { get; set; }

        /// <summary>
        /// 客户满意度分数
        /// </summary>
        public decimal SatisfactsCore { get; set; }

        /// <summary>
        /// 客户不满意原因等
        /// </summary>
        public string UnsatisFactreason { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}