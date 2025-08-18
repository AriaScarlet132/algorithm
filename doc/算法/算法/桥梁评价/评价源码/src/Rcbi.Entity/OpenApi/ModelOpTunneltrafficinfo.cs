using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �����ͨ����ҵ����Ϣ
    /// </summary>
    public class ModelOpTunneltrafficinfo
    {
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public string TaskNo { get; set; }

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        [Required(ErrorMessage = "��ʼ��������Ϊ����")]
        public DateTime BuildStartDate { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [Required(ErrorMessage = "������������Ϊ����")]
        public DateTime BuildEndDate { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [Required(ErrorMessage = "������������Ϊ����")]
        public DateTime CommitDate { get; set; }

        /// <summary>
        /// ��ʼ��Ӫ����
        /// </summary>
        [Required(ErrorMessage = "��ʼ��Ӫ����Ϊ����")]
        public DateTime OpstartDate { get; set; }

        /// <summary>
        /// ������ʼ����
        /// </summary>
        [Required(ErrorMessage = "������ʼ����Ϊ����")]
        public DateTime BigMaintainStartDate { get; set; }

        /// <summary>
        /// ���޽�������
        /// </summary>
        [Required(ErrorMessage = "���޽�������Ϊ����")]
        public DateTime BigMaintainEndDate { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [Required(ErrorMessage = "�����Ϊ����")]
        public int EntryAmount { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public int ExitAmount { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        [Required(ErrorMessage = "�ṹ����Ϊ����")]
        public string StructureType { get; set; }

        /// <summary>
        /// ���з���
        /// </summary>
        [Required(ErrorMessage = "���з���Ϊ����")]
        public string TunnelDirection { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public string CqType { get; set; }

        /// <summary>
        /// �Ƿ�Խ��
        /// </summary>
        [Required(ErrorMessage = "�Ƿ�Խ��Ϊ����")]
        public string Crossriver { get; set; }

        /// <summary>
        /// ��Ӫ����
        /// </summary>
        [Required(ErrorMessage = "��Ӫ����Ϊ����")]
        public string Opattribute { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Required(ErrorMessage = "�������Ϊ����")]
        public decimal TunnelLength { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public decimal TunnelWidth { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Required(ErrorMessage = "�������Ϊ����")]
        public decimal TunnelPureWidth { get; set; }

        /// <summary>
        /// ������״
        /// </summary>
        [Required(ErrorMessage = "������״Ϊ����")]
        public string TunnelShape { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Required(ErrorMessage = "�������Ϊ����")]
        public decimal CqThick { get; set; }

        /// <summary>
        /// ����ǿ��
        /// </summary>
        [Required(ErrorMessage = "����ǿ��Ϊ����")]
        public decimal CqStrength { get; set; }

        /// <summary>
        /// ����ٶ�
        /// </summary>
        [Required(ErrorMessage = "����ٶ�Ϊ����")]
        public decimal DesignSpeed { get; set; }

        /// <summary>
        /// ����غ�
        /// </summary>
        [Required(ErrorMessage = "����غ�Ϊ����")]
        public decimal DesignLoading { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Required(ErrorMessage = "�������Ϊ����")]
        public decimal DesignFlowing { get; set; }

        /// <summary>
        /// ҵ����λ
        /// </summary>
        [Required(ErrorMessage = "ҵ����λΪ����")]
        public string OwnerUnit { get; set; }

        /// <summary>
        /// ��Ƶ�λ
        /// </summary>
        [Required(ErrorMessage = "��Ƶ�λΪ����")]
        public string DesignUnit { get; set; }

        /// <summary>
        /// ʩ����λ
        /// </summary>
        [Required(ErrorMessage = "ʩ����λΪ����")]
        public string ContructUnit { get; set; }

        /// <summary>
        /// ��Ӫ��λ
        /// </summary>
        [Required(ErrorMessage = "��Ӫ��λΪ����")]
        public string OperationUnit { get; set; }

        /// <summary>
        /// ����������ͬ��ʼ����
        /// </summary>
        [Required(ErrorMessage = "����������ͬ��ʼ����Ϊ����")]
        public DateTime NewContractStartDate { get; set; }

        /// <summary>
        /// ����������ͬ��������
        /// </summary>
        [Required(ErrorMessage = "����������ͬ��������Ϊ����")]
        public DateTime NewContractEndDate { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Required(ErrorMessage = "��������ʱ��Ϊ����")]
        //public DateTime DataPushDate { get; set; }

      
    }
}