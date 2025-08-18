using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ʻ����DSIҵ����Ϣ
    /// </summary>
    public class ModelOpDsidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// ��·��
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// �۲�����
        /// </summary>
        public DateTime MonitorDate { get; set; }

        /// <summary>
        /// l�۲����·�ι�·���ȣ�km)
        /// </summary>
        public decimal MonitorLength { get; set; }

        /// <summary>
        /// t��i�۲⳵ͨ����·�ε��г�ʱ�䣨Сʱ��
        /// </summary>
        public decimal PassTime { get; set; }

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