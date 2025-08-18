using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ�ķ�ϵͳ�����۽��
    /// </summary>
    public class ModelMesResultMidsystem
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
        /// �����ϵͳ����
        /// </summary>
        [Column("name_Midsystem")]
        public string NameMidsystem { get; set; }

        /// <summary>
        /// �����ϵͳ����
        /// </summary>
        [Column("code_Midsystem")]
        public string CodeMidsystem { get; set; }

        /// <summary>
        /// �����ϵͳ����״��ָ��
        /// </summary>
        [Column("CI_Midsystem")]
        public string CIMidsystem { get; set; }

        /// <summary>
        /// �÷�
        /// </summary>
        [Column("score")]
        public decimal Score { get; set; }

        /// <summary>
        /// �ȼ�
        /// </summary>
        [Column("grade")]
        public string Grade { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// Ȩ��ֵ
        /// </summary>
        public decimal? weight_value { get; set; }

    }
}