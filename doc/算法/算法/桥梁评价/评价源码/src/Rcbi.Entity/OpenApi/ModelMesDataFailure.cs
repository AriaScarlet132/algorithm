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
    public class ModelMesDataFailure
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
        /// �豸���Ͽ�ʼʱ��
        /// </summary>
        [Required(ErrorMessage = "�豸���Ͽ�ʼʱ��Ϊ����")]
        public DateTime BeginningFailure { get; set; }

        /// <summary>
        /// �豸���Ͻ���ʱ��
        /// </summary>
        public DateTime EndingFailure { get; set; }

        /// <summary>
        /// �ۼƹ���ʱ��
        /// </summary>
        [Required(ErrorMessage = "�ۼƹ���ʱ��Ϊ����")]
        public int TotalFailure { get; set; }

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