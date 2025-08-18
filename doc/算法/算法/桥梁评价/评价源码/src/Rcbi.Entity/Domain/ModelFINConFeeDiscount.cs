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
    [Table("tb_model_FIN_Con_FeeDiscount")]
    public class ModelFINConFeeDiscount : BaseModelEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// 费用名称
        /// </summary>
        [Column("ItemName")]
        public string ItemName { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        [Column("Ratio")]
        public decimal Ratio { get; set; }

        /// <summary>
        /// 配置编号
        /// </summary>
        [Column("ConfigID")]
        public string ConfigID { get; set; }
    }
}

