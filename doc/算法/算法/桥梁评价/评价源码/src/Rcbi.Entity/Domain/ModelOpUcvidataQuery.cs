using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// �û������UCVIҵ����Ϣ
    /// </summary>
    public class ModelOpUcvidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string DataYear { get; set; }

        /// <summary>
        /// �·�
        /// </summary>
        public string DataMonth { get; set; }

        /// <summary>
        /// n�����š����á�����δ��ʱ��������
        /// </summary>
        public string DelayAmount { get; set; }

        /// <summary>
        /// n�����š����á�����Ӧ��������
        /// </summary>
        public decimal HandleAmount { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }

        /// <summary>
        /// ����Ͷ����  V2
        /// </summary>
        public int? Nr { get; set; }
        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}