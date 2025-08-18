using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ʩ��Ԫ�ṹ��Ϣ
    /// </summary>
    public class ModelTjTunnelsection
    {
        /// <summary>
        /// ����Ԫ
        /// </summary>
        [Required(ErrorMessage = "����ԪΪ����")]
        public string ManagementUnit { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        [Required(ErrorMessage = "�ṹ����Ϊ����")]
        public string StructureSection { get; set; }

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
        /// ���۵�Ԫ����
        /// </summary>
        [Required(ErrorMessage = "���۵�Ԫ����Ϊ����")]
        public string Code_Section { get; set; }

        /// <summary>
        /// ����̺�
        /// </summary>
        [Required(ErrorMessage = "����̺�Ϊ����")]
        public string Start_mileage { get; set; }

        /// <summary>
        /// ֹ��̺�
        /// </summary>
        [Required(ErrorMessage = "ֹ��̺�Ϊ����")]
        public string End_mileage { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string Project_Code { get; set; }
    }
}