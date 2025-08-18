using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�Ļ���ϵͳ�豸���������Ϣ
    /// </summary>
    public class ModelMesDataOperation
    {
        /// <summary>
        /// �豸����
        /// </summary>
        [Required(ErrorMessage = "�豸����Ϊ����")]
        public string EquipmentName { get; set; }

        /// <summary>
        /// �豸����
        /// </summary>
        [Required(ErrorMessage = "�豸����Ϊ����")]
        public string EquipmentCode { get; set; }

        /// <summary>
        /// �豸���п�ʼʱ��
        /// </summary>
        [Required(ErrorMessage = "�豸���п�ʼʱ��Ϊ����")]
        public DateTime BeginningOperation { get; set; }

        /// <summary>
        /// �豸���н���ʱ��
        /// </summary>
        [Required(ErrorMessage = "�豸���н���ʱ��Ϊ����")]
        public DateTime EndingOperation { get; set; }

        /// <summary>
        /// �ۼ�����ʱ��
        /// </summary>
        [Required(ErrorMessage = "�ۼ�����ʱ��Ϊ����")]
        public int TotalOperation { get; set; }

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

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Column("datapushdate")]
        //public DateTime Datapushdate { get; set; }

    }
}