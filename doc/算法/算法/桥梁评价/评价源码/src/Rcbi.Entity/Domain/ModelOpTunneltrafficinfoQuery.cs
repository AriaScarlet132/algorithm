using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// �����ͨ����ҵ����Ϣ
    /// </summary>
    public class ModelOpTunneltrafficinfoQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjecName { get; set; }

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        public DateTime BuildStartDate { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        public DateTime BuildEndDate { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        public DateTime CommitDate { get; set; }

        /// <summary>
        /// ��ʼ��Ӫ����
        /// </summary>
        public DateTime OpstartDate { get; set; }

        /// <summary>
        /// ������ʼ����
        /// </summary>
        public DateTime BigMaintainStartDate { get; set; }

        /// <summary>
        /// ���޽�������
        /// </summary>
        public DateTime BigMaintainEndDate { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public int EntryAmount { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int ExitAmount { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// ���з���
        /// </summary>
        public string TunnelDirection { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string CqType { get; set; }

        /// <summary>
        /// �Ƿ�Խ��
        /// </summary>
        public string Crossriver { get; set; }

        /// <summary>
        /// ��Ӫ����
        /// </summary>
        public string Opattribute { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public decimal TunnelLength { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public decimal TunnelWidth { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public decimal TunnelPureWidth { get; set; }

        /// <summary>
        /// ������״
        /// </summary>
        public string TunnelShape { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public decimal CqThick { get; set; }

        /// <summary>
        /// ����ǿ��
        /// </summary>
        public decimal CqStrength { get; set; }

        /// <summary>
        /// ����ٶ�
        /// </summary>
        public decimal DesignSpeed { get; set; }

        /// <summary>
        /// ����غ�
        /// </summary>
        public decimal DesignLoading { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public decimal DesignFlowing { get; set; }

        /// <summary>
        /// ҵ����λ
        /// </summary>
        public string OwnerUnit { get; set; }

        /// <summary>
        /// ��Ƶ�λ
        /// </summary>
        public string DesignUnit { get; set; }

        /// <summary>
        /// ʩ����λ
        /// </summary>
        public string ContructUnit { get; set; }

        /// <summary>
        /// ��Ӫ��λ
        /// </summary>
        public string OperationUnit { get; set; }

        /// <summary>
        /// ����������ͬ��ʼ����
        /// </summary>
        public DateTime NewContractStartDate { get; set; }

        /// <summary>
        /// ����������ͬ��������
        /// </summary>
        public DateTime NewContractEndDate { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}