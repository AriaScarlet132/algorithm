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
    [Table("tb_model_FIN_Con_ProjectCount")]
    public class ModelFINConProjectCount : BaseModelEntity
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
        /// 用户输入工程量
        /// </summary>
        [Column("InputMaitainItemWork")]
        public float InputMaitainItemWork { get; set; }

        /// <summary>
        /// 转换后的比列值
        /// </summary>
        [Column("TransformedMaitainItemWork")]
        public decimal TransformedMaitainItemWork { get; set; }

        /// <summary>
        /// 配置编号
        /// </summary>
        [Column("ConfigID")]
        public string ConfigID { get; set; }
    }
}



