using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ȫ�¹���RVҵ����Ϣ
    /// </summary>
    public class ModelOpRvdataQuery : LayuiQuery
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
        /// ���
        /// </summary>
        public int MonitorYear { get; set; }

        /// <summary>
        /// �·�
        /// </summary>
        public int MonitorMonth { get; set; }

        /// <summary>
        /// �¹���
        /// </summary>
        public int Accident_Num { get; set; }

        /// <summary>
        /// ��ê��
        /// </summary>
        public int Broke_Down { get; set; }

        /// <summary>
        /// ƽ��������
        /// </summary>
        public decimal Average_Stream { get; set; }

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