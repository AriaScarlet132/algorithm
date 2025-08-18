using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的分系统级评价结果
    /// </summary>
    public class ModelMesResultMidsystem
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [Column("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Column("end")]
        public DateTime End { get; set; }

        /// <summary>
        /// 机电分系统名称
        /// </summary>
        [Column("name_Midsystem")]
        public string NameMidsystem { get; set; }

        /// <summary>
        /// 机电分系统编码
        /// </summary>
        [Column("code_Midsystem")]
        public string CodeMidsystem { get; set; }

        /// <summary>
        /// 机电分系统技术状况指数
        /// </summary>
        [Column("CI_Midsystem")]
        public string CIMidsystem { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        [Column("score")]
        public decimal Score { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [Column("grade")]
        public string Grade { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 权重值
        /// </summary>
        public decimal? weight_value { get; set; }

    }
}