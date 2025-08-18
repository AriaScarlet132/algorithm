using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������DIҵ����Ϣ
    /// </summary>
    public class ModelOpDidata
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
        public string MonitorYear { get; set; }

        /// <summary>
        /// �·�-����
        /// </summary>
        [Required(ErrorMessage = "�·�-����Ϊ����")]
        public string MonitorMonthDay { get; set; }

        /// <summary>
        /// ���ֵ1
        /// </summary>
        [Required(ErrorMessage = "���ֵ1Ϊ����")]
        public decimal MonitorDataDay { get; set; }

        /// <summary>
        /// �·�-����
        /// </summary>
        [Required(ErrorMessage = "�·�-����Ϊ����")]
        public string MonitorMonthNight { get; set; }

        /// <summary>
        /// ���ֵ2
        /// </summary>
        [Required(ErrorMessage = "���ֵ2Ϊ����")]
        public decimal MonitorDataNight { get; set; }

        /// <summary>
        /// ���ֵ
        /// </summary>
        [Required(ErrorMessage = "���ֵΪ����")]
        public decimal MonitorData { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}