using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ͨ����DTI��·ҵ����Ϣ
    /// </summary>
    public class ModelOpDtidata
    {
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string Project_Code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��·��
        /// </summary>
        [Required(ErrorMessage = "��·��Ϊ����")]
        public string LineCode { get; set; }

        /// <summary>
        /// �۲�����
        /// </summary>
        [Required(ErrorMessage = "�۲�����Ϊ����")]
        public DateTime MonitorDate { get; set; }

        /// <summary>
        /// �����������
        /// </summary>
        [Required(ErrorMessage = "�����������Ϊ����")]
        public int TunneltrafficTotal { get; set; }

        /// <summary>
        /// ������������Сʱ��
        /// </summary>
        [Required(ErrorMessage = "������������Сʱ��Ϊ����")]
        public int TunneltrafficMax { get; set; }

        /// <summary>
        /// ���5:00-7:00��Сʱ����
        /// </summary>
        [Required(ErrorMessage = "���5:00-7:00��Сʱ����Ϊ����")]
        public int Tunneltraffic57 { get; set; }

        /// <summary>
        /// ���17:00-19:00��Сʱ����
        /// </summary>
        [Required(ErrorMessage = "���17:00-19:00��Сʱ����Ϊ����")]
        public int Tunneltraffic1719 { get; set; }

        /// <summary>
        /// ����1���
        /// </summary>
        [Required(ErrorMessage = "����1���Ϊ����")]
        public string Lane1 { get; set; }

        /// <summary>
        /// ����1���������գ�
        /// </summary>
        [Required(ErrorMessage = "����1���������գ�Ϊ����")]
        public int Lane1Trafficnum { get; set; }

        /// <summary>
        /// ����1��5:00-7:00��Сʱ����
        /// </summary>
        [Required(ErrorMessage = "����1��5:00-7:00��Сʱ����Ϊ����")]
        public int Lane1Traffic57 { get; set; }

        /// <summary>
        /// ����1��17:00-19:00��Сʱ����
        /// </summary>
        [Required(ErrorMessage = "����1��17:00-19:00��Сʱ����Ϊ����")]
        public int Lane1Traffic1719 { get; set; }

        /// <summary>
        /// ����2���
        /// </summary>
        [Required(ErrorMessage = "����2���Ϊ����")]
        public string Lane2 { get; set; }

        /// <summary>
        /// ����2���������գ�
        /// </summary>
        [Required(ErrorMessage = "����2���������գ�Ϊ����")]
        public int Lane2Trafficnum { get; set; }

        /// <summary>
        /// ����2��5:00-7:00��Сʱ����
        /// </summary>
        [Required(ErrorMessage = "����2��5:00-7:00��Сʱ����Ϊ����")]
        public int Lane2Traffic57 { get; set; }

        /// <summary>
        /// ����2��17:00-19:00��Сʱ����
        /// </summary>
        [Required(ErrorMessage = "����2��17:00-19:00��Сʱ����Ϊ����")]
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

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }


        /// <summary>
        /// ��   v2
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// �۲��·�   v2
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// �߷���ƽ��ÿ�쳵������4Сʱ��(pcu/d)     v2
        /// </summary>
        public double? TrafficPeak4h { get; set; }

        /// <summary>
        /// �¶��ܳ�����(pcu/m)v2   v2
        /// </summary>
        public long? TrafficTotal { get; set; }

        /// <summary>
        /// С�ͳ��¶��ܳ����� (pcu/m) v2   v2
        /// </summary>
        public long? MiniBus { get; set; }

        /// <summary>
        /// ���Ϳͳ��¶��ܳ�����(pcu/m) v2   v2
        /// </summary>
        public long? LargeBus { get; set; }

        /// <summary>
        /// ���ͻ����¶��ܳ�����(pcu/m)v2   v2
        /// </summary>
        public long? LargeTruck { get; set; }

        /// <summary>
        /// �½ӳ��¶��ܳ����� (pcu/m)v2   v2
        /// </summary>
        public long? Articulated { get; set; }
    }
}