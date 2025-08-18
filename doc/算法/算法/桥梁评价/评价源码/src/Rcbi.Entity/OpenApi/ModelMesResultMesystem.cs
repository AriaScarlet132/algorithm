using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�Ļ���ϵͳ�������۽��
    /// </summary>
    public class ModelMesResultMesystem
    {
        /// <summary>
        /// ��ʼ����
        /// </summary>
        [Column("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("end")]
        public DateTime End { get; set; }

        /// <summary>
        /// ����ϵͳ����
        /// </summary>
        [Column("name_MESystem")]
        public string NameMESystem { get; set; }

        /// <summary>
        /// ����ϵͳ����
        /// </summary>
        [Column("code_MESystem")]
        public string CodeMESystem { get; set; }

        /// <summary>
        /// ����ϵͳ����״��ָ��
        /// </summary>
        [Column("CI_MESystem")]
        public string CIMESystem { get; set; }

        /// <summary>
        /// �÷�
        /// </summary>
        [Column("score")]
        public decimal Score { get; set; }

        /// <summary>
        /// ����ϵͳ�ȼ�
        /// </summary>
        [Column("grade")]
        public string Grade { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }
    }
}