using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 系统 角色-菜单-权限 关系
    /// </summary>
    [Table("sys_role_menu_auth")]
    public class RoleMenuAuth : BaseModelEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        [Column("menu_id")]
        public int MenuId { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>
        [Column("auth_code")]
        public string AuthCode { get; set; }

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
    }
}
