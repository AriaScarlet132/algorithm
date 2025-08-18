using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ���۵�Ԫ��Ϣ
    /// </summary>
    public class ModelTjDataStructurefacility
    {

        /// <summary>
        /// ��ʩ����
        /// </summary>
        [Required(ErrorMessage = "��ʩ����Ϊ����")]
        public string Code { get; set; }

        /// <summary>
        /// ��ʩ����
        /// </summary>
        [Required(ErrorMessage = "��ʩ����Ϊ����")]
        public string Name { get; set; }

        /// <summary>
        /// ����Ԫ
        /// </summary>
        [Required(ErrorMessage = "����ԪΪ����")]
        public string ManagementUnit { get; set; }

        /// <summary>
        /// �����·
        /// </summary>
        [Required(ErrorMessage = "�����·Ϊ����")]
        public string Line { get; set; }

        /// <summary>
        /// �ṹ���ԣ����ࣩ
        /// </summary>
        [Required(ErrorMessage = "�ṹ����Ϊ����")]
        public string StructureAtt { get; set; }

        /// <summary>
        /// �ṹ���
        /// </summary>
        [Required(ErrorMessage = "�ṹ���Ϊ����")]
        public string StructureType { get; set; }

        /// <summary>
        /// �������ͣ�С�ࣩ
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public string ComponentType { get; set; }

        /// <summary>
        /// ����̺�
        /// </summary>
        [Required(ErrorMessage = "����̺�Ϊ����")]
        public string Start_Mileage { get; set; }

        /// <summary>
        /// ֹ��̺�
        /// </summary>
        [Required(ErrorMessage = "ֹ��̺�Ϊ����")]
        public string End_Mileage { get; set; }

        /// <summary>
        /// ��Ӧ���۵�Ԫ����
        /// </summary>
        [Required(ErrorMessage = "��Ӧ���۵�Ԫ����Ϊ����")]
        public string Code_Section { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required(ErrorMessage = "��Ŀ����Ϊ����")]
        public string Project_Code { get; set; }


        /// <summary>
        /// �����· v2
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// �ṹ���  v2
        /// </summary>
        public string SectionName { get; set; }
        /// <summary>
        /// ���۵�Ԫ����  v2
        /// </summary>
        public string SectionCode { get; set; }
        /// <summary>
        /// �������ͱ���   v2
        /// </summary>
        public string ComponentCode { get; set; }
    }
}