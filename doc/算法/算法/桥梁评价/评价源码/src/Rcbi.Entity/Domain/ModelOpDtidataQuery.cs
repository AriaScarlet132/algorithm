using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ͨ����DTI��·ҵ����Ϣ
    /// </summary>
    public class ModelOpDtidataQuery : LayuiQuery
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
        /// �����������
        /// </summary>
        public int TunneltrafficTotal { get; set; }

        /// <summary>
        /// ������������Сʱ��
        /// </summary>
        public int TunneltrafficMax { get; set; }

        /// <summary>
        /// ���5:00-7:00��Сʱ����
        /// </summary>
        public int Tunneltraffic57 { get; set; }

        /// <summary>
        /// ���17:00-19:00��Сʱ����
        /// </summary>
        public int Tunneltraffic1719 { get; set; }

        /// <summary>
        /// ����1���
        /// </summary>
        public string Lane1 { get; set; }

        /// <summary>
        /// ����1���������գ�
        /// </summary>
        public int Lane1Trafficnum { get; set; }

        /// <summary>
        /// ����1��5:00-7:00��Сʱ����
        /// </summary>
        public int Lane1Traffic57 { get; set; }

        /// <summary>
        /// ����1��17:00-19:00��Сʱ����
        /// </summary>
        public int Lane1Traffic1719 { get; set; }

        /// <summary>
        /// ����2���
        /// </summary>
        public string Lane2 { get; set; }

        /// <summary>
        /// ����2���������գ�
        /// </summary>
        public int Lane2Trafficnum { get; set; }

        /// <summary>
        /// ����2��5:00-7:00��Сʱ����
        /// </summary>
        public int Lane2Traffic57 { get; set; }

        /// <summary>
        /// ����2��17:00-19:00��Сʱ����
        /// </summary>
        public int Lane2Traffic1719 { get; set; }

        /// <summary>
        /// ����3���
        /// </summary>
        public string Lane3 { get; set; }

        /// <summary>
        /// ����3���������գ�
        /// </summary>
        public int Lane3Trafficnum { get; set; }

        /// <summary>
        /// ����3��5:00-7:00��Сʱ����
        /// </summary>
        public int Lane3Traffic57 { get; set; }

        /// <summary>
        /// ����3��17:00-19:00��Сʱ����
        /// </summary>
        public int Lane3Traffic1719 { get; set; }

        /// <summary>
        /// ����4���
        /// </summary>
        public string Lane4 { get; set; }

        /// <summary>
        /// ����4���������գ�
        /// </summary>
        public int Lane4Trafficnum { get; set; }

        /// <summary>
        /// ����4��5:00-7:00��Сʱ����
        /// </summary>
        public int Lane4Traffic57 { get; set; }

        /// <summary>
        /// ����4��17:00-19:00��Сʱ����
        /// </summary>
        public int Lane4Traffic1719 { get; set; }

        /// <summary>
        /// ����5���
        /// </summary>
        public string Lane5 { get; set; }

        /// <summary>
        /// ����5���������գ�
        /// </summary>
        public int Lane5Trafficnum { get; set; }

        /// <summary>
        /// ����5��5:00-7:00��Сʱ����
        /// </summary>
        public int Lane5Traffic57 { get; set; }

        /// <summary>
        /// ����5��17:00-19:00��Сʱ����
        /// </summary>
        public int Lane5Traffic1719 { get; set; }

        /// <summary>
        /// ����6���
        /// </summary>
        public string Lane6 { get; set; }

        /// <summary>
        /// ����6���������գ�
        /// </summary>
        public int Lane61Trafficnum { get; set; }

        /// <summary>
        /// ����6��5:00-7:00��Сʱ����
        /// </summary>
        public int Lane6Traffic57 { get; set; }

        /// <summary>
        /// ����6��17:00-19:00��Сʱ����
        /// </summary>
        public int Lane6Traffic1719 { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }


        /// <summary>
        /// �۲���� v2
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// �۲��·� v2
        /// </summary>
        public int? Month { get; set; }
        /// <summary>
        /// �߷���ƽ��ÿ�쳵������4Сʱ��(pcu/d)   v2
        /// </summary>
        public double? TrafficPeak4h { get; set; }
        /// <summary>
        /// �¶��ܳ�����(pcu/m) v2
        /// </summary>
        public long? TrafficTotal { get; set; }
        /// <summary>
        /// С�ͳ��¶��ܳ����� (pcu/m)   v2
        /// </summary>
        public long? MiniBus { get; set; }
        /// <summary>
        /// ���Ϳͳ��¶��ܳ�����(pcu/m)   v2
        /// </summary>
        public long? LargeBus { get; set; }
        /// <summary>
        /// ���ͻ����¶��ܳ�����(pcu/m)   v2
        /// </summary>
        public long? LargeTruck { get; set; }
        /// <summary>
        /// �½ӳ��¶��ܳ����� (pcu/m)   v2
        /// </summary>
        public long? Articulated { get; set; }

    }
}