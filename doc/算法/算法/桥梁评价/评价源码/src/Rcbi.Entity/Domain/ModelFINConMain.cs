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
    [Table("tb_model_FIN_Con_Main")]
    public class ModelFINConMain : BaseModelEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// 配置编号
        /// </summary>
        [Column("ConfigID")]
        public string ConfigID { get; set; }
        /// <summary>
        /// 计算模式
        /// </summary>
        [Column("TaskModel")]
        public string TaskModel { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("ProjectID")]
        public int ProjectID { get; set; }
        /// <summary>
        /// 定额规范年份
        /// </summary>
        [Column("SpecYear")]
        public int SpecYear { get; set; }
        /// <summary>
        /// 材料市场价格年份
        /// </summary>
        [Column("PriceYear")]
        public int PriceYear { get; set; }

        /// <summary>
        /// 配置时间
        /// </summary>
        [Column("ConfigDate")]
        public DateTime ConfigDate { get; set; }

    }
}

//TaskModel 计算模式
//ProjectID 项目编号
//SpecYear 定额规范年份
//PriceYear 材料市场价格年份
//ConfigDate 配置时间

