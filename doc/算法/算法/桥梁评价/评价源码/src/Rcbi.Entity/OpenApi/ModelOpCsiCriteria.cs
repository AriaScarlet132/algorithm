using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �û�����ָ�����۵ȼ�
    /// </summary>
    public class ModelOpCsiCriteria
    {
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string ProjectCode { get; set; }
        /// <summary>
        /// �ȼ�����
        /// </summary>
        [Required(ErrorMessage = "�ȼ�����Ϊ����")]
        public int MinValue { get; set; }

        /// <summary>
        /// �ȼ�����
        /// </summary>
        [Required(ErrorMessage = "�ȼ�����Ϊ����")]
        public int MaxValue { get; set; }

        /// <summary>
        /// �ȼ�����
        /// </summary>
        [Required(ErrorMessage = "�ȼ�����Ϊ����")]
        public string LevelName { get; set; }

        /// <summary>
        /// �ȼ�ֵ
        /// </summary>
        [Required(ErrorMessage = "�ȼ�ֵΪ����")]
        public int LevelValue { get; set; }

    }
}