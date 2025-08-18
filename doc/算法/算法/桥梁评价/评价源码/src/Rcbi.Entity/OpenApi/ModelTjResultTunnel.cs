using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�������ṹ���۽��
    /// </summary>
    public class ModelTjResultTunnel
    {
        /// <summary>
        /// ��ʼ����
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// ���۵÷�
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// ���۵ȼ�
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }
    }
}