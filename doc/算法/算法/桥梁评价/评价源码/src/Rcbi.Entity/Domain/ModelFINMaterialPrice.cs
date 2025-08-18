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
    [Table("tb_model_FIN_MaterialPrice")]
    public class ModelFINMaterialPrice : BaseModelEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// 材料编号
        /// </summary>
        [Column("MaterialID")]
        public string MaterialID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("MaterialName")]
        public string MaterialName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Column("MaterialUnit")]
        public string MaterialUnit { get; set; }

        /// <summary>
        /// 成本类别
        /// </summary>
        [Column("CostType")]
        public string CostType { get; set; }

        /// <summary>
        /// 材料单价
        /// </summary>
        [Column("MaterialPrice")]
        public decimal MaterialPrice { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [Column("PriceYear")]
        public int PriceYear { get; set; }

    }
}
