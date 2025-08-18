using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Rcbi.Core.Attributes;
using Rcbi.Entity.Enums;

namespace Rcbi.Entity.Framework
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    [Table("sys_menu")]
    [Serializable]
    public class MenuEntity : BaseModelEntity
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Key]
        [Column("menu_id")]
        public int MenuId { get; set; }

        /// <summary>
        /// 系统编码
        /// </summary>
        [Column("system_code")]
        public string SystemCode { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Column("menu_code")]
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("menu_name")]
        public string MenuName { get; set; }

        /// <summary>
        /// 上级菜单ID
        /// </summary>
        [Column("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Column("menu_url")]
        public string Url { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [Column("icon")]
        public string Icon { get; set; }

        [Column("menu_type")]
        public MenuType MenuType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comment { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [Column("is_disable")]
        public bool IsDisable { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("hasAuth")]
        public bool HasAuth { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [JsonIgnore]
        [XmlIgnore]
        public IList<MenuEntity> Childrens { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [JsonIgnore]
        [XmlIgnore]
        public bool IsOpen { get; set; }

        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [JsonIgnore]
        [XmlIgnore]
        public bool IsLeaf 
        {
            get {
                return this.Childrens == null || this.Childrens.Count == 0;
            }
        }

        [NotQuery]
        [NotInsert]
        [NotUpdate]
        [JsonProperty("isLeaf")]
        public bool IsLeafForGrid
        {
            get;
            set;
        }

        [NotQuery]
        [NotInsert]
        [NotUpdate]
        [JsonProperty("expanded")]
        public bool Expanded
        {
            get;
            set;
        }
        [NotQuery]
        [NotInsert]
        [NotUpdate]
        [JsonProperty("level")]
        public int Level
        {
            get;
            set;
        }

        [NotQuery]
        [NotInsert]
        [NotUpdate]
        [JsonProperty("parent")]
        public string Parent
        {
            get;
            set;
        }
    }
}
