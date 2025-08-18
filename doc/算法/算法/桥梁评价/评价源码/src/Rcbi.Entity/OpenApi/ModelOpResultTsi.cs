using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��Ӫ����ͨ������ָ�����۽��
    /// </summary>
    public class ModelOpResultTsi
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

        [Column("DTI_Value")]
        public string DtiValue { get; set; }


        [Column("DTI_Score")]
        public string DtiScore { get; set; }

        /// <summary>
        /// dti�ȼ�����
        /// </summary>
        [Column("DTI_Description")]
        public string DtiDescription { get; set; }

        /// <summary>
        /// dsi������
        /// </summary>
        [Column("DSI_Value")]
        public decimal DsiValue { get; set; }

        /// <summary>
        /// dsi��Ӧ��ֵ����
        /// </summary>
        [Column("DSI_Score")]
        public decimal DsiScore { get; set; }

        /// <summary>
        /// dsi����
        /// </summary>
        [Column("DSI_Level")]
        public decimal DsiLevel { get; set; }

        /// <summary>
        /// dsi�ȼ�����
        /// </summary>
        [Column("DSI_Description")]
        public string DsiDescription { get; set; }

        /// <summary>
        /// dfr������
        /// </summary>
        [Column("DFR_Value")]
        public decimal DfrValue { get; set; }

        /// <summary>
        /// dfr��Ӧ��ֵ����
        /// </summary>
        [Column("DFR_Score")]
        public decimal DfrScore { get; set; }

        /// <summary>
        /// dfr����
        /// </summary>
        [Column("DFR_Level")]
        public decimal DfrLevel { get; set; }

        /// <summary>
        /// dfr�ȼ�����
        /// </summary>
        [Column("DFR_Description")]
        public string DfrDescription { get; set; }

        /// <summary>
        /// tei������
        /// </summary>
        [Column("TEI_Value")]
        public decimal TeiValue { get; set; }

        /// <summary>
        /// tei��Ӧ��ֵ����
        /// </summary>
        [Column("TEI_Score")]
        public decimal TeiScore { get; set; }

        /// <summary>
        /// tei����
        /// </summary>
        [Column("TEI_Level")]
        public decimal TeiLevel { get; set; }

        /// <summary>
        /// tei�ȼ�����
        /// </summary>
        [Column("TEI_Description")]
        public string TeiDescription { get; set; }

        /// <summary>
        /// lr������
        /// </summary>
        [Column("LR_Value")]
        public decimal LrValue { get; set; }

        /// <summary>
        /// lr��Ӧ��ֵ����
        /// </summary>
        [Column("LR_Score")]
        public decimal LrScore { get; set; }

        /// <summary>
        /// lr����
        /// </summary>
        [Column("LR_Level")]
        public decimal LrLevel { get; set; }

        /// <summary>
        /// lr�ȼ�����
        /// </summary>
        [Column("LR_Description")]
        public string LrDescription { get; set; }

       
    }
}