using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    ///�����������ҵ����Ϣ
    /// </summary>
    public class ModelOpLaneinfo
    {
        /// <summary>
        /// ��·��
        /// </summary>
        [Required(ErrorMessage = "��·��Ϊ����")]
        public string LineCode { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public string LaneCode { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Required(ErrorMessage = "�������Ϊ����")]
        public decimal LaneWidth { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public decimal LaneLength { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required(ErrorMessage = "��Ŀ����Ϊ����")]
        public string ProjectName { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        [Required(ErrorMessage = "��עΪ����")]
        public string Memo { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}