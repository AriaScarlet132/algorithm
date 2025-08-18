using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 项目-附件 关系
    /// </summary>
    [Table("tb_project_attachmet")]
    public class ProjectAttachment : BaseModelEntity
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("attachment_id")]
        public int AttachmentId { get; set; }

        [Column("sort_num")]
        public int Sort { get; set; }

        [Column("comments")]
        public string Comments { get; set; }

        [Column("project_attachment_type")]
        public string ProjectAttachmentType { get; set; }
    }
}
