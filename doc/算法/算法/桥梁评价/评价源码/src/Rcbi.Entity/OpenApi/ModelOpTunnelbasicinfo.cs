using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ���������Ϣ
    /// </summary>
    public class ModelOpTunnelbasicinfo
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
        public string CrosSriver { get; set; }

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
        /// ��Ƶ������
        /// </summary>
        [Required(ErrorMessage = "��Ƶ������Ϊ����")]
        public decimal DesignShaft { get; set; }

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

        /// <summary>
        /// ���Ȼ��ն�bi���Ҫ��
        /// </summary>
        [Required(ErrorMessage = "���Ȼ��ն�bi���Ҫ��Ϊ����")]
        public decimal DesignBi { get; set; }

        /// <summary>
        /// ����di���Ҫ��
        /// </summary>
        [Required(ErrorMessage = "����di���Ҫ��Ϊ����")]
        public decimal DesignDi { get; set; }

        /// <summary>
        /// pmŨ�����Ҫ��
        /// </summary>
        [Required(ErrorMessage = "pmŨ�����Ҫ��Ϊ����")]
        public decimal DesignPm { get; set; }

        /// <summary>
        /// coŨ�����Ҫ��
        /// </summary>
        [Required(ErrorMessage = "coŨ�����Ҫ��Ϊ����")]
        public decimal DesignCo { get; set; }

        /// <summary>
        /// vi���Ҫ��
        /// </summary>
        [Required(ErrorMessage = "vi���Ҫ��Ϊ����")]
        public decimal DesignVi { get; set; }

        /// <summary>
        /// MCI�ӷ�����
        /// </summary>
        [Required(ErrorMessage = "MCI�ӷ�����Ϊ����")]
        public decimal DesignMCIScore { get; set; }


        /// <summary> 
        /// ������� v2
        /// </summary> 
        public string TunnelType { get; set; }
        /// <summary>
        /// ��ڼ�ǿ���������ֵ  v2
        /// </summary>
        public int? DesignEntranceBI { get; set; }
        /// <summary>
        /// ���ڼ�ǿ���������ֵ  v2
        /// </summary>
        public int? DesignExitBI { get; set; }
        /// <summary>
        /// �������������ֵ  v2
        /// </summary>
        public int? DesignBaseBI { get; set; }
    }
}