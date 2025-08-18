using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�Ĺ������÷ּ�����Ϣ
    /// </summary>
    public class ModelTjResultComponenttype
    {
        /// <summary>
        /// ʱ��
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ��·
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureSection { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// �ṹ���
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// ���۵�Ԫ
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// ������Ҫ��
        /// </summary>
        public string Component_Importance { get; set; }

        /// <summary>
        /// �÷�
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// ���۵�Ԫ����v2
        /// </summary>
        public string section_code { get; set; }
    }
}