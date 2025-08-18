using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �ṹȱ����Ϣ
    /// </summary>
    public class ModelTjDataDefects
    {

        /// <summary>
        /// ʱ��
        /// </summary>
        [Required(ErrorMessage = "ʱ��Ϊ����")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// ��·
        /// </summary>
        [Required(ErrorMessage = "��·��Ϊ����")]
        public string Line { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        [Required(ErrorMessage = "�ṹ����Ϊ����")]
        public string StructureSection { get; set; }

        /// <summary>
        /// ����Ԫ����
        /// </summary>
        [Required(ErrorMessage = "����Ԫ����Ϊ����")]
        public string ManagementUnit { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        [Required(ErrorMessage = "�ṹ����Ϊ����")]
        public string StructureAtt { get; set; }

        /// <summary>
        /// �ṹ���
        /// </summary>
        [Required(ErrorMessage = "�ṹ���Ϊ����")]
        public string StructureType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public string ComponentType { get; set; }

        /// <summary>
        /// ���׮��
        /// </summary>
        [Required(ErrorMessage = "���׮��Ϊ����")]
        public string Mileage { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Defect { get; set; }

        /// <summary>
        /// ������̬
        /// </summary>
        public string DefectType { get; set; }

        /// <summary>
        /// ���س̶�
        /// </summary>
        [Required(ErrorMessage = "���س̶�Ϊ����")]
        public string DefectSeverity { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string DefectDescription { get; set; }

        /// <summary>
        /// ��Ƭ����
        /// </summary>
        public string RingNumber { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string Project_Code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��·���
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// ���۵�Ԫ����
        /// </summary>
        public string SectionName { get; set; }
        /// <summary>
        /// ���۵�Ԫ����
        /// </summary>
        public string SectionCode { get; set; }
    }
}