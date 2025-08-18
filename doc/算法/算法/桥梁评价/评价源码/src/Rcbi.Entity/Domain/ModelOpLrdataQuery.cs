using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ͨ·�����LRҵ����Ϣ
    /// </summary>
    public class ModelOpLrdataQuery : LayuiQuery
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
        /// ������
        /// </summary>
        public int TotalCar { get; set; }

        /// <summary>
        /// С�ͳ���
        /// </summary>
        public int SmallCarAmount { get; set; }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        public int BigCarAmount { get; set; }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        public int MediumCarAmount { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int TruckAmount { get; set; }

        /// <summary>
        /// �ͳ�1��
        /// </summary>
        public int BusAmount1 { get; set; }

        /// <summary>
        /// �ͳ�2��
        /// </summary>
        public int BusAmount2 { get; set; }

        /// <summary>
        /// �ͳ�3��
        /// </summary>
        public int BusAmount3 { get; set; }

        /// <summary>
        /// �ͳ�4��
        /// </summary>
        public int BusAmount4 { get; set; }

        /// <summary>
        /// ����1��
        /// </summary>
        public int VanAmount1 { get; set; }

        /// <summary>
        /// ����2��
        /// </summary>
        public int VanAmount2 { get; set; }

        /// <summary>
        /// ����3��
        /// </summary>
        public int VanAmount3 { get; set; }

        /// <summary>
        /// ����4��
        /// </summary>
        public int VanAmount4 { get; set; }

        /// <summary>
        /// ����5��
        /// </summary>
        public int VanAmount5 { get; set; }

        /// <summary>
        /// ����1��
        /// </summary>
        public int TruckAmount1 { get; set; }

        /// <summary>
        /// ����2��
        /// </summary>
        public int TruckAmount2 { get; set; }

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