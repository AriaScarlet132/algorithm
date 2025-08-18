using System;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 字典类型
    /// </summary>
    [Table("sys_general")]
    public class General : BaseModelEntity
    {
        /// <summary>
        /// 通用编号
        /// </summary>
        [Column("general_code")]
        public string GeneralCode { get; set; }

        /// <summary>
        /// 通用名称
        /// </summary>
        [Column("general_name")]
        public string GeneralName { get; set; }

        /// <summary>
        /// 通用分类
        /// </summary>
        [Column("general_type_id")]
        public int GeneralTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("is_tree")]
        public int IsTree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("is_system")]
        public int IsSystem { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int SortNum { get; set; }

        /// <summary>
        /// 内容名称1
        /// </summary>
        [Column("content_name")]
        public string ContentName1 { get; set; }

        /// <summary>
        /// 内容类型
        /// </summary>
        [Column("content_type")]
        public string ContentType1 { get; set; }

        /// <summary>
        /// 内容名称2
        /// </summary>
        [Column("content_name_2")]
        public string ContentName2 { get; set; }

        /// <summary>
        /// 内容类型2
        /// </summary>
        [Column("content_type_2")]
        public string ContentType2 { get; set; }

        /// <summary>
        /// 内容名称3
        /// </summary>
        [Column("content_name_3")]
        public string ContentName3 { get; set; }

        /// <summary>
        /// 内容类型3
        /// </summary>
        [Column("content_type_3")]
        public string ContentType3 { get; set; }

        /// <summary>
        /// 内容名称4
        /// </summary>
        [Column("content_name_4")]
        public string ContentName4 { get; set; }

        /// <summary>
        /// 内容类型4
        /// </summary>
        [Column("content_type_4")]
        public string ContentType4 { get; set; }

        /// <summary>
        /// 内容名称5
        /// </summary>
        [Column("content_name_5")]
        public string ContentName5 { get; set; }

        /// <summary>
        /// 内容类型5
        /// </summary>
        [Column("content_type_5")]
        public string ContentType5 { get; set; }

        /// <summary>
        /// 内容名称6
        /// </summary>
        [Column("content_name_6")]
        public string ContentName6 { get; set; }

        /// <summary>
        /// 内容类型6
        /// </summary>
        [Column("content_type_6")]
        public string ContentType6 { get; set; }

        /// <summary>
        /// 内容名称7
        /// </summary>
        [Column("content_name_7")]
        public string ContentName7 { get; set; }

        /// <summary>
        /// 内容类型7
        /// </summary>
        [Column("content_type_7")]
        public string ContentType7 { get; set; }

        /// <summary>
        /// 内容名称8
        /// </summary>
        [Column("content_name_8")]
        public string ContentName8 { get; set; }

        /// <summary>
        /// 内容类型9
        /// </summary>
        [Column("content_type_8")]
        public string ContentType8 { get; set; }

        /// <summary>
        /// 内容名称9
        /// </summary>
        [Column("content_name_9")]
        public string ContentName9 { get; set; }

        /// <summary>
        /// 内容类型9
        /// </summary>
        [Column("content_type_9")]
        public string ContentType9 { get; set; }

        /// <summary>
        /// 内容名称10
        /// </summary>
        [Column("content_name_10")]
        public string ContentName10 { get; set; }

        /// <summary>
        /// 内容类型10
        /// </summary>
        [Column("content_type_10")]
        public string ContentType10 { get; set; }

        /// <summary>
        /// 通用描述
        /// </summary>
        [Column("comments")]
        public string Comments { get; set; }

        [Column("update_count")]
        public string UpdateCount { get; set; }
    }
}