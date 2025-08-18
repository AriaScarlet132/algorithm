using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ͨ��ͨ��DFRҵ����Ϣ
    /// </summary>
    public class ModelOpDfrdata
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
        /// ��·��
        /// </summary>
        [Required(ErrorMessage = "��·��Ϊ����")]
        public string LineCode { get; set; }

        /// <summary>
        /// �۲�����
        /// </summary>
        [Required(ErrorMessage = "�۲�����Ϊ����")]
        public DateTime MonitorDate { get; set; }

        /// <summary>
        /// ������ʱ�䣨Сʱ��
        /// </summary>
        [Required(ErrorMessage = "������ʱ�䣨Сʱ��Ϊ����")]
        public decimal DelayTimes { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}