using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ����DIҵ����Ϣ
    /// </summary>
    public class ModelOpDidataQuery : LayuiQuery
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
        /// ��װλ��
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// ���׮��
        /// </summary>
        public string Mileage { get; set; }

        /// <summary>
        /// �豸���
        /// </summary>
        public string DeviceNo { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string MonitorYear { get; set; }

        /// <summary>
        /// �·�-����
        /// </summary>
        public string MonitorMonthDay { get; set; }

        /// <summary>
        /// ���ֵ1
        /// </summary>
        public decimal MonitorDataDay { get; set; }

        /// <summary>
        /// �·�-����
        /// </summary>
        public string MonitorMonthNight { get; set; }

        /// <summary>
        /// ���ֵ2
        /// </summary>
        public decimal MonitorDataNight { get; set; }

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