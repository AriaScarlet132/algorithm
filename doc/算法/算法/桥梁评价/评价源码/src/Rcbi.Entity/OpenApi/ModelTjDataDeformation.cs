using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public class ModelTjDataDeformation
    {
        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "ʱ��Ϊ����")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ��̺�
        /// </summary>
        [Required(ErrorMessage = "��̺�Ϊ����")]
        public string Station { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string ValueCode { get; set; }

        /// <summary>
        /// ֵ
        /// </summary>
        [Required(ErrorMessage = "���ֵΪ����")]
        public decimal? DeformationValue { get; set; }

        /// <summary>
        /// ֵ
        /// </summary>
        public decimal? Value { get; set; }

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

        ///// <summary>
        ///// ֱ���仯��
        ///// </summary>
        //public decimal? deformationValue { get; set; }
    }
}