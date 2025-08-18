using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{ /// <summary>
  /// 待评价项目的机电系统设备运行情况信息
  /// </summary>
    public class ModelMesDataOperationList
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
        /// 设备运行开始时间
        /// </summary>
        [Column("beginning_Operation")]
        public DateTime? BeginningOperation { get; set; }

        /// <summary>
        /// 设备运行结束时间
        /// </summary>
        [Column("ending_Operation")]
        public DateTime? EndingOperation { get; set; }

        /// <summary>
        /// 运行总时长
        /// </summary>
        [Column("total_Operation")]
        public int? TotalOperation { get; set; }

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
