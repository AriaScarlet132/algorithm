using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ҵ�ɱ���ЧMCIҵ����Ϣ
    /// </summary>
    public class ModelOpMcidata
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
        /// �·�
        /// </summary>
        [Required(ErrorMessage = "�·�Ϊ����")]
        public int Month { get; set; }

        /// <summary>
        /// ʵ�ʳɱ�
        /// </summary>
        [Required(ErrorMessage = "ʵ�ʳɱ�Ϊ����")]
        public decimal RealCost { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Required(ErrorMessage = "ʵ������Ϊ����")]
        public decimal RealPerformance { get; set; }

        /// <summary>
        /// ʵ�ʳɱ���������ʱ��
        /// </summary>
        [Required(ErrorMessage = "ʵ�ʳɱ���������ʱ��Ϊ����")]
        public DateTime RealDate { get; set; }

        /// <summary>
        /// �ƻ��ɱ�
        /// </summary>
        [Required(ErrorMessage = "�ƻ��ɱ�Ϊ����")]
        public decimal PlanCost { get; set; }

        /// <summary>
        /// �ƻ�����
        /// </summary>
        [Required(ErrorMessage = "�ƻ�����Ϊ����")]
        public decimal PlanPerformance { get; set; }

        /// <summary>
        /// ����ɱ���������ʱ��
        /// </summary>
        [Required(ErrorMessage = "����ɱ���������ʱ��Ϊ����")]
        public DateTime PlanDate { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [Required(ErrorMessage = "���Ϊ����")]
        public string DocYear { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}