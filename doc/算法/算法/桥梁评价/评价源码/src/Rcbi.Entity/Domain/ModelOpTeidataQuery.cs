using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ǣ���Ŷ�TEIҵ����Ϣ
    /// </summary>
    public class ModelOpTeidataQuery : LayuiQuery
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
        /// m1���������¹�֪ͨʱ��-ǣ��������ʱ�䣩<=2���ӣ�
        /// </summary>
        public int M1amount { get; set; }

        /// <summary>
        /// m2��������ǣ��������ʱ��-ǣ��������ǣ���ص�ʱ�䣩<=20���ӣ�
        /// </summary>
        public int M2amount { get; set; }

        /// <summary>
        /// ����ǣ���ܴ���
        /// </summary>
        public int Totalinday { get; set; }

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