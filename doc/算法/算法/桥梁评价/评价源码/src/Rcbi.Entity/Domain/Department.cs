using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    [Table("sys_org_dept")]
    public class Department : BaseModelEntity
    {
        /// <summary>
        /// 组织编码
        /// </summary>
        [Key]
        [Column("dept_id")]
        public int DeptId { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        [Column("dept_code")]
        public string DeptCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("dept_name")]
        public string DeptName { get; set; }

        /// <summary>
        /// 父级部门
        /// </summary>
        [Column("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// 公司编码
        /// </summary>
        [Column("org_id")]
        public int OrgId { get; set; }

        /// <summary>
        /// 主管人员
        /// </summary>
        [Column("charge_person")]
        public string ChargePerson { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int? Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comment { get; set; }

        [NotInsert]
        [NotUpdate]
        [JsonIgnore]
        [NotQuery]
        [XmlIgnore]
        public IList<Department> Childrens { get; set; }

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
