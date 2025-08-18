using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// �û����ʶ�UCIҵ����Ϣ
    /// </summary>
    public class ModelOpUcidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime InvestDate { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string InvestContent { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string CustomerAge { get; set; }

        /// <summary>
        /// �ͻ��Ա�
        /// </summary>
        public string CustomerSex { get; set; }

        /// <summary>
        /// �ͻ�����ȷ���
        /// </summary>
        public decimal SatisfactsCore { get; set; }

        /// <summary>
        /// �ͻ�������ԭ���
        /// </summary>
        public string UnsatisFactreason { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}