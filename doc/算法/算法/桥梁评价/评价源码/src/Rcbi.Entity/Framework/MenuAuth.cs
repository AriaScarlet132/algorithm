using System;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Framework
{
    [Table("sys_menu_auth")]
    public class MenuAuthEntity : BaseModelEntity
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Column("menu_id")]
        public int MenuId { get; set; }

        /// <summary>
        /// 授权编码
        /// </summary>
        [Column("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 授权名称
        /// </summary>
        [Column("auth_name")]
        public string AuthName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comment { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int Sort { get; set; }
    }
}
