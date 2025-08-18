using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �û������UCVIҵ����Ϣ
    /// </summary>
    public class ModelOpUcvidata
    {
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
        /// ���
        /// </summary>
        [Required(ErrorMessage = "���Ϊ����")]
        public string DataYear { get; set; }

        /// <summary>
        /// �·�
        /// </summary>
        [Required(ErrorMessage = "�·�Ϊ����")]
        public string DataMonth { get; set; }

        /// <summary>
        /// n�����š����á�����δ��ʱ��������
        /// </summary>
        [Required(ErrorMessage = "n�����š����á�����δ��ʱ��������Ϊ����")]
        public string DelayAmount { get; set; }

        /// <summary>
        /// n�����š����á�����Ӧ��������
        /// </summary>
        [Required(ErrorMessage = "n�����š����á�����Ӧ��������Ϊ����")]
        public decimal HandleAmount { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}