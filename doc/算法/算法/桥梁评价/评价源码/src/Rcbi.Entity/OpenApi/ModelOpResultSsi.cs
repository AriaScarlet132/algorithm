using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��Ӫ����ȫ������ָ�����۽��
    /// </summary>
    public class ModelOpResultSsi
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

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        [Column("Start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [Column("End")]
        public DateTime End { get; set; }

        /// <summary>
        /// Rv������
        /// </summary>
        [Column("RV_Value")]
        public decimal RvValue { get; set; }

        /// <summary>
        /// Rv��Ӧ��ֵ����
        /// </summary>
        [Column("RV_Score")]
        public decimal RvScore { get; set; }

        /// <summary>
        /// Rv����
        /// </summary>
        [Column("RV_Level")]
        public decimal RvLevel { get; set; }

        /// <summary>
        /// Rv�ȼ�����
        /// </summary>
        [Column("RV_Description")]
        public string RvDescription { get; set; }

        /// <summary>
        /// VI������
        /// </summary>
        [Column("VI_Value")]
        public decimal ViValue { get; set; }

        /// <summary>
        /// VI��Ӧ��ֵ����
        /// </summary>
        [Column("VI_Score")]
        public decimal ViScore { get; set; }

        /// <summary>
        /// VI����
        /// </summary>
        [Column("VI_Level")]
        public decimal ViLevel { get; set; }

        /// <summary>
        /// VI�ȼ�����
        /// </summary>
        [Column("VI_Description")]
        public string ViDescription { get; set; }

        /// <summary>
        /// CO������
        /// </summary>
        [Column("CO_Value")]
        public decimal CoValue { get; set; }

        /// <summary>
        /// CO��Ӧ��ֵ����
        /// </summary>
        [Column("CO_Score")]
        public decimal CoScore { get; set; }

        /// <summary>
        /// CO����
        /// </summary>
        [Column("CO_Level")]
        public decimal CoLevel { get; set; }

        /// <summary>
        /// CO�ȼ�����
        /// </summary>
        [Column("CO_Description")]
        public string CoDescription { get; set; }

        /// <summary>
        /// PM������
        /// </summary>
        [Column("PM_Value")]
        public decimal PmValue { get; set; }

        /// <summary>
        /// PM��Ӧ��ֵ����
        /// </summary>
        [Column("PM_Score")]
        public decimal PmScore { get; set; }

        /// <summary>
        /// PM����
        /// </summary>
        [Column("PM_Level")]
        public decimal PmLevel { get; set; }

        /// <summary>
        /// PM�ȼ�����
        /// </summary>
        [Column("PM_Description")]
        public string PmDescription { get; set; }

       

     
    }
}