using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�����۵�Ԫ�����۽��
    /// </summary>
    public class ModelTjResultTunnelsection
    {
        /// <summary>
        /// ����
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ��·
        /// </summary>
        public string Line { get; set; }
        /// <summary>
        /// �ṹ����
        /// </summary>

        public string StructureAtt { get; set; }
        /// <summary>
        /// �ṹ���
        /// </summary>

        public string StructureType { get; set; }
        /// <summary>
        /// ���۵�Ԫ
        /// </summary>

        public string Section { get; set; }
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