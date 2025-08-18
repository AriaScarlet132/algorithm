using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 系统附件
    /// </summary>
    [Table("tb_attachment")]
    public class Attachment : BaseModelEntity
    {
        [Key]
        [Column("attachment_id")]
        public int AttachmentId { get; set; }

        [Column("file_name")]
        public string FileName { get; set; }

        [Column("file_path")]
        public string FilePath { get; set; }

        [Column("file_path2")]
        public string FilePath2 { get; set; }

        [Column("file_url")]
        public string FileUrl { get; set; }

        [Column("file_url2")]
        public string FileUrl2 { get; set; }

        [Column("file_type")]
        public string FileType { get; set; }

        [Column("file_size")]
        public double FileSize { get; set; }

        [Column("comments")]
        public string Comments { get; set; }

        [Column("sort_num")]
        public int Sort { get; set; }
    }

    public class AttachmentList: Attachment
    {
        [Column("project_attachment_type")]
        public string ProjectAttachmentType { get; set; }

        [Column("project_attachment_type_name")]
        public string  ProjectAttachmentTypeName { get; set; }
    }
}
