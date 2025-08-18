using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 内业管理制度MSSI业务信息
    /// </summary>
    public class ModelOpMssidata
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
        /// 文档类别
        /// </summary>
        [Required(ErrorMessage = "文档类别为必输")]
        public string DocType { get; set; }

        /// <summary>
        /// 评价规范中的应提交文档名称
        /// </summary>
        [Required(ErrorMessage = "评价规范中的应提交文档名称为必输")]
        public string DocNameSpec { get; set; }

        /// <summary>
        /// 公司档案资料实际名称
        /// </summary>
        [Required(ErrorMessage = "公司档案资料实际名称为必输")]
        public string DocNameCompany { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
        [Required(ErrorMessage = "完成情况为必输")]
        public int DocComplete { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? DocCommitDate { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [Required(ErrorMessage = "年度为必输")]
        public string DocYear { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}