using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ×ÖµäÀàĞÍ
    /// </summary>
    [Table("sys_general_type")]
    public class GeneralType : BaseModelEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("general_type_id")]
        public int GeneralTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("type_id_parent")]
        public int TypeIdParent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("general_type_name")]
        public string GeneralTypeName { get; set; }

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