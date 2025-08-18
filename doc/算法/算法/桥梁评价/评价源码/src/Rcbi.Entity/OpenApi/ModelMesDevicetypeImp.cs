using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 机电系统设备编码与重要度信息
    /// </summary>
    public class ModelMesDevicetypeImp
    {
        /// <summary>
        /// 所属子系统编码
        /// </summary>
        [Column("MesSystemCode")]
        public string MesSystemCode { get; set; }

        /// <summary>
        /// 设备类型名称
        /// </summary>
        [Column("typeName_Equipment")]
        public string TypeNameEquipment { get; set; }

        /// <summary>
        /// 设备类型编码
        /// </summary>
        [Column("typeCode_Equipment")]
        public string TypeCodeEquipment { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Column("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 解释说明
        /// </summary>
        [Column("Explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// 设备类型重要度
        /// </summary>
        [Column("importance_Equipment")]
        public string ImportanceEquipment { get; set; }

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