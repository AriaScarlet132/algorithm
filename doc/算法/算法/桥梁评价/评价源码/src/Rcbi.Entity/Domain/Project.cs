using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 项目信息
    /// </summary>
    [Table("sys_project")]
    [Serializable]
    public class Project : BaseModelEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Column("id")]
        public int ProjectId { get; set; }

        /// <summary>
        /// 项目编码
        /// </summary>
        [Column("code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [Column("short_name")]
        public string ShortName { get; set; }
        /// <summary>
        /// 全称
        /// </summary>
        [Column("full_name")]
        public string FullName { get; set; }
        /// <summary>
        /// 结构类型
        /// </summary>
        [Column("facility_type")]
        public string FacilityType { get; set; }


        /// <summary>
        /// 结构类型-显示
        /// </summary>
        
        [Column("facility_type_value")]
        [NotUpdate]
        [NotInsert] 
        public string FacilityTypeValue { get; set; }

        
        /// <summary>
        /// 地理位置
        /// </summary>
        [Column("position")]
        public string Position { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("comment")]
        public string Comment { get; set; }

    }
}
