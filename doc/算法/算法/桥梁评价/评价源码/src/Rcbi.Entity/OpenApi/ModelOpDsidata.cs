using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ʻ����DSIҵ����Ϣ
    /// </summary>
    public class ModelOpDsidata
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
        /// l�۲����·�ι�·���ȣ�km)
        /// </summary>
        [Required(ErrorMessage = "l�۲����·�ι�·���ȣ�km)Ϊ����")]
        public decimal MonitorLength { get; set; }

        /// <summary>
        /// t��i�۲⳵ͨ����·�ε��г�ʱ�䣨Сʱ��
        /// </summary>
        [Required(ErrorMessage = "t��i�۲⳵ͨ����·�ε��г�ʱ�䣨Сʱ��Ϊ����")]
        public decimal PassTime { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}