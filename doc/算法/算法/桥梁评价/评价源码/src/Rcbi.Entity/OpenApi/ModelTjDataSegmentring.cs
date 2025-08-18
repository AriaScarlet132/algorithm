using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��Ŀ�Ļ�����Ϣ
    /// </summary>
    public class ModelTjDataSegmentring
    {
        /// <summary>
        /// ��·
        /// </summary>
        [Required(ErrorMessage = "��·Ϊ����")]
        public string Line { get; set; }

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
        /// ��Ӧ��Ƭ����
        /// </summary>
        [Required(ErrorMessage = "��Ӧ��Ƭ����Ϊ����")]
        public int RingNumber { get; set; }

        /// <summary>
        /// ��ʼ���
        /// </summary>
        [Required(ErrorMessage = "��ʼ���Ϊ����")]
        public string Start_Mileage { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Required(ErrorMessage = "�������Ϊ����")]
        public string End_Mileage { get; set; }

        /// <summary>
        /// ��Ӧ���۵�Ԫ����
        /// </summary>
        [Required(ErrorMessage = "��Ӧ���۵�Ԫ����Ϊ����")]
        public string Section { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ����Ϊ����")]
        public string Project_Code { get; set; }
    }
}