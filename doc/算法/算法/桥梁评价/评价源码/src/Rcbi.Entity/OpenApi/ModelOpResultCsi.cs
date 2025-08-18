using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��Ӫ�����û�������ָ�����۽��
    /// </summary>
    public class ModelOpResultCsi
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
        /// uci������
        /// </summary>
        [Column("UCI_Value")]
        public decimal UciValue { get; set; }

        /// <summary>
        /// uci��Ӧ��ֵ����
        /// </summary>
        [Column("UCI_Score")]
        public decimal UciScore { get; set; }

        /// <summary>
        /// uci����
        /// </summary>
        [Column("UCI_Level")]
        public decimal UciLevel { get; set; }

        /// <summary>
        /// uci�ȼ�����
        /// </summary>
        [Column("UCI_Description")]
        public string UciDescription { get; set; }

        /// <summary>
        /// di�ռ������
        /// </summary>
        [Column("DI_Day_Value")]
        public decimal DiDayValue { get; set; }

        /// <summary>
        /// di�ռ��Ӧ��ֵ����
        /// </summary>
        [Column("DI_Day_Score")]
        public decimal DiDayScore { get; set; }

        /// <summary>
        /// di�ռ伶��
        /// </summary>
        [Column("DI_Day_Level")]
        public decimal DiDayLevel { get; set; }

        /// <summary>
        /// di�ռ�ȼ�����
        /// </summary>
        [Column("DI_Day_Description")]
        public string DiDayDescription { get; set; }

        /// <summary>
        /// diҹ�������
        /// </summary>
        [Column("DI_Night_Value")]
        public decimal DiNightValue { get; set; }

        /// <summary>
        /// diҹ���Ӧ��ֵ����
        /// </summary>
        [Column("DI_Night_Score")]
        public decimal DiNightScore { get; set; }

        /// <summary>
        /// diҹ�伶��
        /// </summary>
        [Column("DI_Night_Level")]
        public decimal DiNightLevel { get; set; }

        /// <summary>
        /// diҹ��ȼ�����
        /// </summary>
        [Column("DI_Night_Description")]
        public string DiNightDescription { get; set; }

        /// <summary>
        /// bi������
        /// </summary>
        [Column("BI_Value")]
        public decimal BiValue { get; set; }

        /// <summary>
        /// bi��Ӧ��ֵ����
        /// </summary>
        [Column("BI_Score")]
        public decimal BiScore { get; set; }

        /// <summary>
        /// bi����
        /// </summary>
        [Column("BI_Level")]
        public decimal BiLevel { get; set; }

        /// <summary>
        /// bi�ȼ�����
        /// </summary>
        [Column("BI_Description")]
        public string BiDescription { get; set; }

        /// <summary>
        /// uvci������
        /// </summary>
        [Column("UCVI_Value")]
        public decimal UvciValue { get; set; }

        /// <summary>
        /// uvci��Ӧ��ֵ����
        /// </summary>
        [Column("UCVI_Score")]
        public decimal UvciScore { get; set; }

        /// <summary>
        /// uvci����
        /// </summary>
        [Column("UCVI_Level")]
        public decimal UvciLevel { get; set; }

        /// <summary>
        /// uvci�ȼ�����
        /// </summary>
        [Column("UCVI_Description")]
        public string UvciDescription { get; set; }

     
    }
}