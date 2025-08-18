using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ����ϵͳ�����۽��
    /// </summary>
    public class ModelMesResultSubsystem
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
        /// ������ϵͳ����
        /// </summary>
        [Column("name_Subsystem")]
        public string NameSubsystem { get; set; }

        /// <summary>
        /// ������ϵͳ����
        /// </summary>
        [Column("code_Subsystem")]
        public string CodeSubsystem { get; set; }

        /// <summary>
        /// ��ϵͳ�豸�����
        /// </summary>
        [Column("integrityrate_Subsystem")]
        public string IntegrityrateSubsystem { get; set; }

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

        /// <summary>
        /// Ȩ��ֵ
        /// </summary>
        public decimal? weight_value { get; set; }

    }
}