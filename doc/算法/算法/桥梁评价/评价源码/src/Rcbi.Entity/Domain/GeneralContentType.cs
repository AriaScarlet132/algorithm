using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ◊÷µ‰¿‡–Õ
    /// </summary>
    [Table("sys_general_content_type")]
    public class GeneralContentType : BaseModelEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("content_type_code")]
        public string ContentTypeCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("content_type_name")]
        public string ContentTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("integer_length")]
        public int IntegerLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("decimal_length")]
        public int DecimalLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("format_string")]
        public string FormatString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("sort_num")]
        public int SortNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("update_count")]
        public int UpdateCount { get; set; }
    }
}