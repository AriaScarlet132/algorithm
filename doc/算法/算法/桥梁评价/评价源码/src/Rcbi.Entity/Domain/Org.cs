using System;
using System.Xml.Serialization;
using System.Collections.Generic;

using Rcbi.Core.Attributes;
using Newtonsoft.Json;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 组织架构
    /// </summary>
    [Table("sys_org")]
    public class Org : BaseModelEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Column("org_id")]
        public int OrgId { get; set; }

        /// <summary>
        /// 单位识别码
        /// </summary>
        [Column("company_code")]
        public string CompanyCode { get; set; }

        /// <summary>
        /// 组织编号
        /// </summary>
        [Column("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织全称
        /// </summary>
        [Column("org_name")]
        public string OrgName { get; set; }

        /// <summary>
        /// 组织简称
        /// </summary>
        [Column("org_name_short")]
        public string OrgNameShort { get; set; }

        /// <summary>
        /// 组织类型
        /// </summary>
        [Column("org_type")]
        public string OrgType { get; set; }

        /// <summary>
        /// 上级组织
        /// </summary>
        [Column("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// 主管人员
        /// </summary>
        [Column("charge_person")]
        public string ChargePerson { get; set; }

        /// <summary>
        /// 单位银行开户名称
        /// </summary>
        [Column("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// 开户银行名称
        /// </summary>
        [Column("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [Column("bank_num")]
        public string BankNum { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("address")]
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [Column("zip_code")]
        public string ZipCode { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [Column("fax_num")]
        public string FaxNum { get; set; }

        /// <summary>
        /// 法人姓名
        /// </summary>
        [Column("legal_person_name")]
        public string LegalPersonName { get; set; }

        /// <summary>
        /// 法人身份证号码
        /// </summary>
        [Column("legal_person_id_num")]
        public string LegalPersonIdNum { get; set; }

        /// <summary>
        /// 法人办公电话
        /// </summary>
        [Column("legal_person_tel")]
        public string LegalPersonTel { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Column("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("contact_tel")]
        public string ContactTel { get; set; }

        /// <summary>
        /// 联系人邮箱
        /// </summary>
        [Column("contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int? Sort { get; set; }

        /// <summary>
        /// 台座布局
        /// </summary>
        [Column("pedestal_layout")]
        public string PedestalLayout { get; set; }

        /// <summary>
        /// 仓库布局
        /// </summary>
        [Column("warehouse_layout")]
        public string WarehouseLayout { get; set; }

        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comment { get; set; }

        [NotQuery]
        [NotInsert]
        [NotUpdate]
        [JsonIgnore]
        [XmlIgnore]
        public IList<Org> Childrens { get; set; }

        [NotQuery]
        [NotInsert]
        [NotUpdate]
        [JsonIgnore]
        [XmlIgnore]
        public bool IsLeaf
        {
            get
            {
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

    /// <summary>
    /// 施工单位
    /// </summary>
    public class ConstructOrg : Org
    {
        /// <summary>
        /// 所属项目
        /// </summary>
        [Column("org_project_id")]
        public int? ProjectId { get; set; }
    }
}