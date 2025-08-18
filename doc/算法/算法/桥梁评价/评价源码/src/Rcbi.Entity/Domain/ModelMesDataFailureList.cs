using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class ModelMesDataFailureList
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [Column("Equipment_Name")]
        public string EquipmentName { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        [Column("Equipment_Code")]
        public string EquipmentCode { get; set; }

        /// <summary>
        /// 设备故障开始时间
        /// </summary>
        [Column("beginning_Failure")]
        public DateTime? BeginningFailure { get; set; }

        /// <summary>
        /// 设备故障结束时间
        /// </summary>
        [Column("ending_Failure")]
        public DateTime? EndingFailure { get; set; }

        /// <summary>
        /// 运行总时长
        /// </summary>
        [Column("total_Failure")]
        public int? TotalFailure { get; set; }

        /// <summary>
        /// 项目号
        /// </summary>
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        [Column("datapushdate")]
        public DateTime? Datapushdate { get; set; }
    }
}
