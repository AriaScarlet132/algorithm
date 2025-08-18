using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 机电系统设备清单信息
    /// </summary>
    public class ModelMesEquipmentlist
    {
        /// <summary>
        /// 设备类型编码
        /// </summary>
        [Column("typeCode_Equipment")]
        public string TypeCodeEquipment { get; set; }

        /// <summary>
        /// 设备类型名称
        /// </summary>
        [Column("typeName_Equipment")]
        public string TypeNameEquipment { get; set; }

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
        /// 项目编号
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Column("datapushdate")]
        //public DateTime Datapushdate { get; set; }

    }
}