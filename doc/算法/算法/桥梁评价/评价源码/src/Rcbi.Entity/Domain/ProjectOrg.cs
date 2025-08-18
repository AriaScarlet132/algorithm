using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 项目-组织 关系
    /// </summary>
    [Table("tb_project_org")]
    public class ProjectOrg : BaseModelEntity
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("org_id")]
        public int OrgId { get; set; }

        [Column("sort_num")]
        public int Sort { get; set; }

        [Column("comments")]
        public string Comments { get; set; }
    }
}
