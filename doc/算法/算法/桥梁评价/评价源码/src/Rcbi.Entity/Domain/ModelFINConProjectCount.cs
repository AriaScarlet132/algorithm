using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 材料单价表
    /// </summary>
    [Table("tb_model_FIN_Con_ProjectUnitCount")]
    public class ModelFINConProjectUnitCount : BaseModelEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// 单元编号
        /// </summary>
        [Column("SectionUnitID")]
        public string SectionUnitID { get; set; }

        /// <summary>
        /// 维护项目编号
        /// </summary>
        [Column("MaintainItemID")]
        public string MaintainItemID { get; set; }

        /// <summary>
        /// 单位工程量
        /// </summary>
        [Column("MaitainItemWorkAmount")]
        public decimal MaitainItemWorkAmount { get; set; }

        /// <summary>
        /// 配置编号
        /// </summary>
        [Column("ConfigID")]
        public string ConfigID { get; set; }
    }
}

