using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 隧道交通流量业务信息
    /// </summary>
    public class ModelOpTunneltrafficinfoQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        /// <summary>
        /// 起始建设日期
        /// </summary>
        public DateTime BuildStartDate { get; set; }

        /// <summary>
        /// 结束建设日期
        /// </summary>
        public DateTime BuildEndDate { get; set; }

        /// <summary>
        /// 竣工验收日期
        /// </summary>
        public DateTime CommitDate { get; set; }

        /// <summary>
        /// 起始运营日期
        /// </summary>
        public DateTime OpstartDate { get; set; }

        /// <summary>
        /// 大修起始日期
        /// </summary>
        public DateTime BigMaintainStartDate { get; set; }

        /// <summary>
        /// 大修结束日期
        /// </summary>
        public DateTime BigMaintainEndDate { get; set; }

        /// <summary>
        /// 入口数
        /// </summary>
        public int EntryAmount { get; set; }

        /// <summary>
        /// 出口数
        /// </summary>
        public int ExitAmount { get; set; }

        /// <summary>
        /// 结构类型
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// 车行方向
        /// </summary>
        public string TunnelDirection { get; set; }

        /// <summary>
        /// 衬砌类型
        /// </summary>
        public string CqType { get; set; }

        /// <summary>
        /// 是否越江
        /// </summary>
        public string Crossriver { get; set; }

        /// <summary>
        /// 经营属性
        /// </summary>
        public string Opattribute { get; set; }

        /// <summary>
        /// 隧道长度
        /// </summary>
        public decimal TunnelLength { get; set; }

        /// <summary>
        /// 隧道宽度
        /// </summary>
        public decimal TunnelWidth { get; set; }

        /// <summary>
        /// 隧道净宽
        /// </summary>
        public decimal TunnelPureWidth { get; set; }

        /// <summary>
        /// 断面形状
        /// </summary>
        public string TunnelShape { get; set; }

        /// <summary>
        /// 衬砌厚度
        /// </summary>
        public decimal CqThick { get; set; }

        /// <summary>
        /// 衬砌强度
        /// </summary>
        public decimal CqStrength { get; set; }

        /// <summary>
        /// 设计速度
        /// </summary>
        public decimal DesignSpeed { get; set; }

        /// <summary>
        /// 设计载荷
        /// </summary>
        public decimal DesignLoading { get; set; }

        /// <summary>
        /// 设计流量
        /// </summary>
        public decimal DesignFlowing { get; set; }

        /// <summary>
        /// 业主单位
        /// </summary>
        public string OwnerUnit { get; set; }

        /// <summary>
        /// 设计单位
        /// </summary>
        public string DesignUnit { get; set; }

        /// <summary>
        /// 施工单位
        /// </summary>
        public string ContructUnit { get; set; }

        /// <summary>
        /// 运营单位
        /// </summary>
        public string OperationUnit { get; set; }

        /// <summary>
        /// 最新养护合同起始日期
        /// </summary>
        public DateTime NewContractStartDate { get; set; }

        /// <summary>
        /// 最新养护合同结束日期
        /// </summary>
        public DateTime NewContractEndDate { get; set; }

        /// <summary>
        /// 数据推送时间
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