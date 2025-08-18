using System;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    [Table("sys_user_role")]
    public class UserRole : BaseModelEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("role_id")]
        public int? RoleId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comment { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int? Sort { get; set; }
    }
}
