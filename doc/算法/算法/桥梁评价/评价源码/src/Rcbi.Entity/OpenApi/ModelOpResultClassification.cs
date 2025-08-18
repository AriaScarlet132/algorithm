using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    ///  ��Ӫ���������Ŀ���۽��
    /// </summary>
    public class ModelOpResultClassification
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
        /// tsi������
        /// </summary>
        [Column("TSI_Value")]
        public decimal TsiValue { get; set; }

        /// <summary>
        /// tsi����
        /// </summary>
        [Column("TSI_Level")]
        public decimal TsiLevel { get; set; }

        /// <summary>
        /// ssi������
        /// </summary>
        [Column("SSI_Value")]
        public decimal SsiValue { get; set; }

        /// <summary>
        /// ssi����
        /// </summary>
        [Column("SSI_Level")]
        public decimal SsiLevel { get; set; }

        /// <summary>
        /// csi������
        /// </summary>
        [Column("CSI_Value")]
        public decimal CsiValue { get; set; }

        /// <summary>
        /// csi����
        /// </summary>
        [Column("CSI_Level")]
        public decimal CsiLevel { get; set; }

        /// <summary>
        /// msi����
        /// </summary>
        [Column("MSI_Value")]
        public decimal MsiValue { get; set; }

        /// <summary>
        /// ms����
        /// </summary>
        [Column("MSI_Level")]
        public decimal MsiLevel { get; set; }
    }
}