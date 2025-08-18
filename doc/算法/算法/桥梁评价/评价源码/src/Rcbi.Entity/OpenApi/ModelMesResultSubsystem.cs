using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的子系统级评价结果
    /// </summary>
    public class ModelMesResultSubsystem
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
        /// 机电子系统名称
        /// </summary>
        [Column("name_Subsystem")]
        public string NameSubsystem { get; set; }

        /// <summary>
        /// 机电子系统编码
        /// </summary>
        [Column("code_Subsystem")]
        public string CodeSubsystem { get; set; }

        /// <summary>
        /// 子系统设备完好率
        /// </summary>
        [Column("integrityrate_Subsystem")]
        public string IntegrityrateSubsystem { get; set; }

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

        /// <summary>
        /// 权重值
        /// </summary>
        public decimal? weight_value { get; set; }

    }
}