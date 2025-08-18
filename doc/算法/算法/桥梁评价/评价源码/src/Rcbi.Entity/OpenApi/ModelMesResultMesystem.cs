using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的机电系统总体评价结果
    /// </summary>
    public class ModelMesResultMesystem
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
        /// 机电系统名称
        /// </summary>
        [Column("name_MESystem")]
        public string NameMESystem { get; set; }

        /// <summary>
        /// 机电系统编码
        /// </summary>
        [Column("code_MESystem")]
        public string CodeMESystem { get; set; }

        /// <summary>
        /// 机电系统技术状况指数
        /// </summary>
        [Column("CI_MESystem")]
        public string CIMESystem { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        [Column("score")]
        public decimal Score { get; set; }

        /// <summary>
        /// 机电系统等级
        /// </summary>
        [Column("grade")]
        public string Grade { get; set; }

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
    }
}