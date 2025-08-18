using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��Ӫ�������弼��״�����۽��
    /// </summary>
    public class ModelOpResultAll
    {
        /// <summary>
        /// ������
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        ///// <summary>
        ///// ��ʼʱ��
        ///// </summary>
        //[Column("Start")]
        //public DateTime Start { get; set; }

        ///// <summary>
        ///// ����ʱ��
        ///// </summary>
        //[Column("End")]
        //public DateTime End { get; set; }

        /// <summary>
        /// fwci����
        /// </summary>
        [Column("FWCI_Value")]
        public decimal FwciValue { get; set; }

        /// <summary>
        /// fwci�ȼ�
        /// </summary>
        [Column("FWCI_Level")]
        public string FwciLevel { get; set; }

        /// <summary>
        /// ָ������   V3
        /// </summary>
        public string  name { get; set; }
        /// <summary>
        /// ָ������   V3
        /// </summary>
        public string  code { get; set; }
        /// <summary>
        /// �ȼ�����    V3
        /// </summary>
        public string level_description { get; set; }
        /// <summary>
        /// ɾ�����    V3
        /// </summary>
        public string delete_flag { get; set; }
    }
}