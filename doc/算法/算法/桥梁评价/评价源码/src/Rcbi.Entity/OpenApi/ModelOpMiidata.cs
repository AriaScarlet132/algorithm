using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ҵ����������Ϣ��MIIҵ����Ϣ
    /// </summary>
    public class ModelOpMiidata
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
        /// �ĵ�����
        /// </summary>
        //[Required(ErrorMessage = "�ĵ�����Ϊ����")]
        public string DocCode { get; set; }

        /// <summary>
        /// ���۹淶�е�Ӧ�ύ�ĵ�����
        /// </summary>
        [Required(ErrorMessage = "���۹淶�е�Ӧ�ύ�ĵ�����Ϊ����")]
        public string DocNameSpec { get; set; }

        /// <summary>
        /// ��˾��������ʵ������
        /// </summary>
        //[Required(ErrorMessage = "��˾��������ʵ������Ϊ����")]
        public string DocNameCompany { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public int DocComplete { get; set; }

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