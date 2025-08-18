using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ǣ���Ŷ�TEIҵ����Ϣ
    /// </summary>
    public class ModelOpTeidata
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
        /// m1����
        /// </summary>
        [Required(ErrorMessage = "m1���������¹�֪ͨʱ��-ǣ��������ʱ�䣩<=2���ӣ�Ϊ����")]
        public int M1amount { get; set; }

        /// <summary>
        /// m2����
        /// </summary>
        [Required(ErrorMessage = "m2��������ǣ��������ʱ��-ǣ��������ǣ���ص�ʱ�䣩<=20���ӣ�Ϊ����")]
        public int M2amount { get; set; }

        /// <summary>
        /// ����ǣ���ܴ���
        /// </summary>
        [Required(ErrorMessage = "����ǣ���ܴ���Ϊ����")]
        public int Totalinday { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}