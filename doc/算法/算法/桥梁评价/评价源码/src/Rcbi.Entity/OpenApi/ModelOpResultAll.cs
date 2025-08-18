using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务总体技术状况评价结果
    /// </summary>
    public class ModelOpResultAll
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

        ///// <summary>
        ///// 起始时间
        ///// </summary>
        //[Column("Start")]
        //public DateTime Start { get; set; }

        ///// <summary>
        ///// 结束时间
        ///// </summary>
        //[Column("End")]
        //public DateTime End { get; set; }

        /// <summary>
        /// fwci分数
        /// </summary>
        [Column("FWCI_Value")]
        public decimal FwciValue { get; set; }

        /// <summary>
        /// fwci等级
        /// </summary>
        [Column("FWCI_Level")]
        public string FwciLevel { get; set; }

        /// <summary>
        /// 指数名称   V3
        /// </summary>
        public string  name { get; set; }
        /// <summary>
        /// 指数编码   V3
        /// </summary>
        public string  code { get; set; }
        /// <summary>
        /// 等级描述    V3
        /// </summary>
        public string level_description { get; set; }
        /// <summary>
        /// 删除标记    V3
        /// </summary>
        public string delete_flag { get; set; }
    }
}