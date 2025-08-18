using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Table("sys_role")]
    public class Role : BaseModelEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 系统编码
        /// </summary>
        [Column("system_code")]
        public string SystemCode { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [Column("role_code")]
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name")]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        [NotUpdate]
        [Column("role_type")]
        public int RoleType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comments { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        //[JsonIgnore]
        //[XmlIgnore]
        [Column("content_content")]
        public string ContentSystemCode { get; set; }
    }
}
