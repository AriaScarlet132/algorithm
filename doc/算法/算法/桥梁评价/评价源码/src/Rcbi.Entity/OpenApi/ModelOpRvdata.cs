using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ȫ�¹���RVҵ����Ϣ
    /// </summary>
    public class ModelOpRvdata
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
        /// ���
        /// </summary>
        [Required(ErrorMessage = "���Ϊ����")]
        public int MonitorYear { get; set; }

        /// <summary>
        /// �·�
        /// </summary>
        [Required(ErrorMessage = "�·�Ϊ����")]
        public int MonitorMonth { get; set; }

        /// <summary>
        /// �¹���
        /// </summary>
        [Required(ErrorMessage = "�¹���Ϊ����")]
        public int AccidentNum { get; set; }

        /// <summary>
        /// ��ê��
        /// </summary>
        [Required(ErrorMessage = "��ê��Ϊ����")]
        public int BrokeDown { get; set; }

        /// <summary>
        /// ƽ��������
        /// </summary>
        [Required(ErrorMessage = "ƽ��������Ϊ����")]
        public decimal AverageStream { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}