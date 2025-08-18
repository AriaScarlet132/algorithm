using System;
using System.Xml.Serialization;
using System.Collections.Generic;

using Rcbi.Core.Attributes;
using Newtonsoft.Json;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��֯�ܹ�
    /// </summary>
    [Table("sys_org")]
    public class Org : BaseModelEntity
    {
        /// <summary>
        /// ����
        /// </summary>
        [Key]
        [Column("org_id")]
        public int OrgId { get; set; }

        /// <summary>
        /// ��λʶ����
        /// </summary>
        [Column("company_code")]
        public string CompanyCode { get; set; }

        /// <summary>
        /// ��֯���
        /// </summary>
        [Column("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// ��֯ȫ��
        /// </summary>
        [Column("org_name")]
        public string OrgName { get; set; }

        /// <summary>
        /// ��֯���
        /// </summary>
        [Column("org_name_short")]
        public string OrgNameShort { get; set; }

        /// <summary>
        /// ��֯����
        /// </summary>
        [Column("org_type")]
        public string OrgType { get; set; }

        /// <summary>
        /// �ϼ���֯
        /// </summary>
        [Column("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// ������Ա
        /// </summary>
        [Column("charge_person")]
        public string ChargePerson { get; set; }

        /// <summary>
        /// ��λ���п�������
        /// </summary>
        [Column("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [Column("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// �����˺�
        /// </summary>
        [Column("bank_num")]
        public string BankNum { get; set; }

        /// <summary>
        /// ��ַ
        /// </summary>
        [Column("address")]
        public string Address { get; set; }

        /// <summary>
        /// �ʱ�
        /// </summary>
        [Column("zip_code")]
        public string ZipCode { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("fax_num")]
        public string FaxNum { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("legal_person_name")]
        public string LegalPersonName { get; set; }

        /// <summary>
        /// �������֤����
        /// </summary>
        [Column("legal_person_id_num")]
        public string LegalPersonIdNum { get; set; }

        /// <summary>
        /// ���˰칫�绰
        /// </summary>
        [Column("legal_person_tel")]
        public string LegalPersonTel { get; set; }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        [Column("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        [Column("contact_tel")]
        public string ContactTel { get; set; }

        /// <summary>
        /// ��ϵ������
        /// </summary>
        [Column("contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("sort_num")]
        public int? Sort { get; set; }

        /// <summary>
        /// ̨������
        /// </summary>
        [Column("pedestal_layout")]
        public string PedestalLayout { get; set; }

        /// <summary>
        /// �ֿⲼ��
        /// </summary>
        [Column("warehouse_layout")]
        public string WarehouseLayout { get; set; }

        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// ��ע
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
    /// ʩ����λ
    /// </summary>
    public class ConstructOrg : Org
    {
        /// <summary>
        /// ������Ŀ
        /// </summary>
        [Column("org_project_id")]
        public int? ProjectId { get; set; }
    }
}