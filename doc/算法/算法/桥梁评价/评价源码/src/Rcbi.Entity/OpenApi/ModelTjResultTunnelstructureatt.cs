using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�Ľṹ���Լ����۽��
    /// </summary>
    public class ModelTjResultTunnelstructureatt
    {
        /// <summary>
        /// ��·
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// ���۵÷�
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// ���۵ȼ�
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string Project_Code { get; set; }
    }
}