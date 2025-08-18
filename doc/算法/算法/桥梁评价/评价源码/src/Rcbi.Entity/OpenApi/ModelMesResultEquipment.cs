using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的设备级评价结果
    /// </summary>
    public class ModelMesResultEquipment
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
        /// 设备类型
        /// </summary>
        [Column("TypeName_Equipment")]
        public string TypeNameEquipment { get; set; }

        /// <summary>
        /// 设备类型编码
        /// </summary>
        [Column("TypeCode_Equipment")]
        public string TypeCodeEquipment { get; set; }

        /// <summary>
        /// 设备类型重要度
        /// </summary>
        [Column("importance_Equipment")]
        public string ImportanceEquipment { get; set; }

        /// <summary>
        /// 设备完好率
        /// </summary>
        [Column("integrityrate_Equipment")]
        public string IntegrityrateEquipment { get; set; }

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