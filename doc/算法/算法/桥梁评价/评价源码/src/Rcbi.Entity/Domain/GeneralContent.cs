using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    [Table("sys_general_content")]
    public class GeneralContent : BaseModelEntity
    {
        [Column("general_code")]
        public string GeneralCode { get; set; }

        [Column("general_key")]
        public string GeneralKey { get; set; }

        [Column("general_key_parent")]
        public string GeneralKeyParent { get; set; }

        [Column("sort_num")]
        public int SortNum { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("content2")]
        public string Content2 { get; set; }

        [Column("content3")]
        public string Content3 { get; set; }

        [Column("content4")]
        public string Content4 { get; set; }

        [Column("content5")]
        public string Content5 { get; set; }

        [Column("content6")]
        public string Content6 { get; set; }

        [Column("content7")]
        public string Content7 { get; set; }

        [Column("content8")]
        public string Content8 { get; set; }

        [Column("content9")]
        public string Content9 { get; set; }

        [Column("content10")]
        public string Content10 { get; set; }

        [Column("comments")]
        public string Comments { get; set; }

        [Column("update_count")]
        public string UpdateCount { get; set; }
    }
}
