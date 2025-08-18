using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ҵ�ɱ���ЧMCIҵ����Ϣ
    /// </summary>
    public class ModelOpMcidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// �·�
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// ʵ�ʳɱ�
        /// </summary>
        public decimal RealCost { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        public decimal RealPerformance { get; set; }

        /// <summary>
        /// ʵ�ʳɱ���������ʱ��
        /// </summary>
        public DateTime RealDate { get; set; }

        /// <summary>
        /// �ƻ��ɱ�
        /// </summary>
        public decimal PlanCost { get; set; }

        /// <summary>
        /// �ƻ�����
        /// </summary>
        public decimal PlanPerformance { get; set; }

        /// <summary>
        /// ����ɱ���������ʱ��
        /// </summary>
        public DateTime PlanDate { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }


        /// <summary>
        /// ���
        /// </summary>
        public string DocYear { get; set; }

        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}