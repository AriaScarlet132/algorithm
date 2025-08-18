using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 项目-用户 关系
    /// </summary>
    [Table("tb_project_user")]
    public class ProjectUser : BaseModelEntity
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("sort_num")]
        public int Sort { get; set; }

        [Column("comments")]
        public string Comments { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("real_name")]
        public string RealName { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("mobile")]
        public string Mobile { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("org_name")]
        public string OrgName { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("role_name")]
        public string RoleName { get; set; }
    }
}
