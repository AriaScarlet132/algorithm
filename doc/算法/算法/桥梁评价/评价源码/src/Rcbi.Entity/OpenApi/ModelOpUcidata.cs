using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 用户舒适度UCI业务信息
    /// </summary>
    public class ModelOpUcidata
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必输")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 调查日期
        /// </summary>
        [Required(ErrorMessage = "调查日期为必输")]
        public DateTime InvestDate { get; set; }

        /// <summary>
        /// 调查内容
        /// </summary>
        [Required(ErrorMessage = "调查内容为必输")]
        public string InvestContent { get; set; }

        /// <summary>
        /// 客户年龄
        /// </summary>
        [Required(ErrorMessage = "客户年龄为必输")]
        public string CustomerAge { get; set; }

        /// <summary>
        /// 客户性别
        /// </summary>
        [Required(ErrorMessage = "客户性别为必输")]
        public string CustomerSex { get; set; }

        /// <summary>
        /// 客户满意度分数
        /// </summary>
        [Required(ErrorMessage = "客户满意度分数为必输")]
        public decimal SatisfactsCore { get; set; }

        /// <summary>
        /// 客户不满意原因等
        /// </summary>
        [Required(ErrorMessage = "客户不满意原因等为必输")]
        public string UnsatisFactreason { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}