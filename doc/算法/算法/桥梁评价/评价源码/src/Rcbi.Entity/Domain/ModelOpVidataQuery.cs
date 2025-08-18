using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// �ܼ���VIҵ����Ϣ
    /// </summary>
    public class ModelOpVidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string project_code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string task_no { get; set; }

        /// <summary>
        /// ��·��
        /// </summary>
        public string linecode { get; set; }

        /// <summary>
        /// ��װλ��
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// ���׮��
        /// </summary>
        public string mileage { get; set; }

        /// <summary>
        /// �豸���
        /// </summary>
        public string deviceno { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public int monitoryear { get; set; }

        /// <summary>
        /// �·�
        /// </summary>
        public int monitormonth { get; set; }

        /// <summary>
        /// ���ֵ
        /// </summary>
        public decimal monitordata { get; set; }


        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}