using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��ͨ·�����LRҵ����Ϣ
    /// </summary>
    public class ModelOpLrdata
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
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public int TotalCar { get; set; }

        /// <summary>
        /// С�ͳ���
        /// </summary>
        [Required(ErrorMessage = "С�ͳ���Ϊ����")]
        public int SmallCarAmount { get; set; }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        [Required(ErrorMessage = "���ͳ���Ϊ����")]
        public int BigCarAmount { get; set; }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        [Required(ErrorMessage = "���ͳ���Ϊ����")]
        public int MediumCarAmount { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public int TruckAmount { get; set; }

        /// <summary>
        /// �ͳ�1��
        /// </summary>
        [Required(ErrorMessage = "�ͳ�1��Ϊ����")]
        public int BusAmount1 { get; set; }

        /// <summary>
        /// �ͳ�2��
        /// </summary>
        [Required(ErrorMessage = "�ͳ�2��Ϊ����")]
        public int BusAmount2 { get; set; }

        /// <summary>
        /// �ͳ�3��
        /// </summary>
        [Required(ErrorMessage = "�ͳ�3��Ϊ����")]
        public int BusAmount3 { get; set; }

        /// <summary>
        /// �ͳ�4��
        /// </summary>
        [Required(ErrorMessage = "�ͳ�4��Ϊ����")]
        public int BusAmount4 { get; set; }

        /// <summary>
        /// ����1��
        /// </summary>
        [Required(ErrorMessage = "����1��Ϊ����")]
        public int VanAmount1 { get; set; }

        /// <summary>
        /// ����2��
        /// </summary>
        [Required(ErrorMessage = "����2��Ϊ����")]
        public int VanAmount2 { get; set; }

        /// <summary>
        /// ����3��
        /// </summary>
        [Required(ErrorMessage = "����3��Ϊ����")]
        public int VanAmount3 { get; set; }

        /// <summary>
        /// ����4��
        /// </summary>
        [Required(ErrorMessage = "����4��Ϊ����")]
        public int VanAmount4 { get; set; }

        /// <summary>
        /// ����5��
        /// </summary>
        [Required(ErrorMessage = "����5��Ϊ����")]
        public int VanAmount5 { get; set; }

        /// <summary>
        /// ����1��
        /// </summary>
        [Required(ErrorMessage = "����1��Ϊ����")]
        public int TruckAmount1 { get; set; }

        /// <summary>
        /// ����2��
        /// </summary>
        [Required(ErrorMessage = "����2��Ϊ����")]
        public int TruckAmount2 { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }
    }
}