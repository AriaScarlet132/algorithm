using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��Ӫ������ҵ������ָ�����۽��
    /// </summary>
    public class ModelOpResultMsi
    {
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
        /// mbi������
        /// </summary>
        [Column("MBI_Value")]
        public decimal MbiValue { get; set; }

        /// <summary>
        /// mbi��Ӧ��ֵ����
        /// </summary>
        [Column("MBI_Score")]
        public decimal MbiScore { get; set; }

        /// <summary>
        /// mbi����
        /// </summary>
        [Column("MBI_Level")]
        public decimal MbiLevel { get; set; }

        /// <summary>
        /// mbi�ȼ�����
        /// </summary>
        [Column("MBI_Description")]
        public string MbiDescription { get; set; }

        /// <summary>
        /// mssi������
        /// </summary>
        [Column("MSSI_Value")]
        public decimal MssiValue { get; set; }

        /// <summary>
        /// mssi��Ӧ��ֵ����
        /// </summary>
        [Column("MSSI_Score")]
        public decimal MssiScore { get; set; }

        /// <summary>
        /// mssi����
        /// </summary>
        [Column("MSSI_Level")]
        public decimal MssiLevel { get; set; }

        /// <summary>
        /// mssi�ȼ�����
        /// </summary>
        [Column("MSSI_Description")]
        public string MssiDescription { get; set; }

        /// <summary>
        /// mii������
        /// </summary>
        [Column("MII_Value")]
        public decimal MiiValue { get; set; }

        /// <summary>
        /// mii��Ӧ��ֵ����
        /// </summary>
        [Column("MII_Score")]
        public decimal MiiScore { get; set; }

        /// <summary>
        /// mii����
        /// </summary>
        [Column("MII_Level")]
        public decimal MiiLevel { get; set; }

        /// <summary>
        /// mii�ȼ�����
        /// </summary>
        [Column("MII_Description")]
        public string MiiDescription { get; set; }

        /// <summary>
        /// mci������
        /// </summary>
        [Column("MCI_Value")]
        public decimal MciValue { get; set; }

        /// <summary>
        /// mci��Ӧ��ֵ����
        /// </summary>
        [Column("MCI_Score")]
        public decimal MciScore { get; set; }

        /// <summary>
        /// mci����
        /// </summary>
        [Column("MCI_Level")]
        public decimal MciLevel { get; set; }

        /// <summary>
        /// mci�ȼ�����
        /// </summary>
        [Column("MCI_Description")]
        public string MciDescription { get; set; }

       
    }
}