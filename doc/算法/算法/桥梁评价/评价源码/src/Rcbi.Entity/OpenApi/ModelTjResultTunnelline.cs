using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ����·�����۽��
    /// </summary>
    public class ModelTjResultTunnelline
    {
        /// <summary>
        /// ��·
        /// </summary>
        public string Line { get; set; }

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
        /// �����
        /// </summary>
        public string Task_No { get; set; }
    }
}