using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �û����ʶ�UCIҵ����Ϣ
    /// </summary>
    public class ModelOpUcidata
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
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public DateTime InvestDate { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public string InvestContent { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        [Required(ErrorMessage = "�ͻ�����Ϊ����")]
        public string CustomerAge { get; set; }

        /// <summary>
        /// �ͻ��Ա�
        /// </summary>
        [Required(ErrorMessage = "�ͻ��Ա�Ϊ����")]
        public string CustomerSex { get; set; }

        /// <summary>
        /// �ͻ�����ȷ���
        /// </summary>
        [Required(ErrorMessage = "�ͻ�����ȷ���Ϊ����")]
        public decimal SatisfactsCore { get; set; }

        /// <summary>
        /// �ͻ�������ԭ���
        /// </summary>
        [Required(ErrorMessage = "�ͻ�������ԭ���Ϊ����")]
        public string UnsatisFactreason { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}