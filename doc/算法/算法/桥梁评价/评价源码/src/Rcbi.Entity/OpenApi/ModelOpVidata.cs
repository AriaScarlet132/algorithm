using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �ܼ���VIҵ����Ϣ
    /// </summary>
    public class ModelOpVidata
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
        /// ��װλ��
        /// </summary>
        [Required(ErrorMessage = "��װλ��Ϊ����")]
        public string Position { get; set; }

        /// <summary>
        /// ���׮��
        /// </summary>
        [Required(ErrorMessage = "���׮��Ϊ����")]
        public string Mileage { get; set; }

        /// <summary>
        /// �豸���
        /// </summary>
        [Required(ErrorMessage = "�豸���Ϊ����")]
        public string DeviceNo { get; set; }

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
        /// ���ֵ
        /// </summary>
        [Required(ErrorMessage = "���ֵΪ����")]
        public decimal  MonitorData { get; set; }

    }
}