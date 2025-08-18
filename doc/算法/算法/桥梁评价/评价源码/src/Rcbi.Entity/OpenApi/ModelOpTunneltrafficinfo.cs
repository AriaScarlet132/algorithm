using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 隧道交通流量业务信息
    /// </summary>
    public class ModelOpTunneltrafficinfo
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必输")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 起始建设日期
        /// </summary>
        [Required(ErrorMessage = "起始建设日期为必输")]
        public DateTime BuildStartDate { get; set; }

        /// <summary>
        /// 结束建设日期
        /// </summary>
        [Required(ErrorMessage = "结束建设日期为必输")]
        public DateTime BuildEndDate { get; set; }

        /// <summary>
        /// 竣工验收日期
        /// </summary>
        [Required(ErrorMessage = "竣工验收日期为必输")]
        public DateTime CommitDate { get; set; }

        /// <summary>
        /// 起始运营日期
        /// </summary>
        [Required(ErrorMessage = "起始运营日期为必输")]
        public DateTime OpstartDate { get; set; }

        /// <summary>
        /// 大修起始日期
        /// </summary>
        [Required(ErrorMessage = "大修起始日期为必输")]
        public DateTime BigMaintainStartDate { get; set; }

        /// <summary>
        /// 大修结束日期
        /// </summary>
        [Required(ErrorMessage = "大修结束日期为必输")]
        public DateTime BigMaintainEndDate { get; set; }

        /// <summary>
        /// 入口数
        /// </summary>
        [Required(ErrorMessage = "入口数为必输")]
        public int EntryAmount { get; set; }

        /// <summary>
        /// 出口数
        /// </summary>
        [Required(ErrorMessage = "出口数为必输")]
        public int ExitAmount { get; set; }

        /// <summary>
        /// 结构类型
        /// </summary>
        [Required(ErrorMessage = "结构类型为必输")]
        public string StructureType { get; set; }

        /// <summary>
        /// 车行方向
        /// </summary>
        [Required(ErrorMessage = "车行方向为必输")]
        public string TunnelDirection { get; set; }

        /// <summary>
        /// 衬砌类型
        /// </summary>
        [Required(ErrorMessage = "衬砌类型为必输")]
        public string CqType { get; set; }

        /// <summary>
        /// 是否越江
        /// </summary>
        [Required(ErrorMessage = "是否越江为必输")]
        public string Crossriver { get; set; }

        /// <summary>
        /// 经营属性
        /// </summary>
        [Required(ErrorMessage = "经营属性为必输")]
        public string Opattribute { get; set; }

        /// <summary>
        /// 隧道长度
        /// </summary>
        [Required(ErrorMessage = "隧道长度为必输")]
        public decimal TunnelLength { get; set; }

        /// <summary>
        /// 隧道宽度
        /// </summary>
        [Required(ErrorMessage = "隧道宽度为必输")]
        public decimal TunnelWidth { get; set; }

        /// <summary>
        /// 隧道净宽
        /// </summary>
        [Required(ErrorMessage = "隧道净宽为必输")]
        public decimal TunnelPureWidth { get; set; }

        /// <summary>
        /// 断面形状
        /// </summary>
        [Required(ErrorMessage = "断面形状为必输")]
        public string TunnelShape { get; set; }

        /// <summary>
        /// 衬砌厚度
        /// </summary>
        [Required(ErrorMessage = "衬砌厚度为必输")]
        public decimal CqThick { get; set; }

        /// <summary>
        /// 衬砌强度
        /// </summary>
        [Required(ErrorMessage = "衬砌强度为必输")]
        public decimal CqStrength { get; set; }

        /// <summary>
        /// 设计速度
        /// </summary>
        [Required(ErrorMessage = "设计速度为必输")]
        public decimal DesignSpeed { get; set; }

        /// <summary>
        /// 设计载荷
        /// </summary>
        [Required(ErrorMessage = "设计载荷为必输")]
        public decimal DesignLoading { get; set; }

        /// <summary>
        /// 设计流量
        /// </summary>
        [Required(ErrorMessage = "设计流量为必输")]
        public decimal DesignFlowing { get; set; }

        /// <summary>
        /// 业主单位
        /// </summary>
        [Required(ErrorMessage = "业主单位为必输")]
        public string OwnerUnit { get; set; }

        /// <summary>
        /// 设计单位
        /// </summary>
        [Required(ErrorMessage = "设计单位为必输")]
        public string DesignUnit { get; set; }

        /// <summary>
        /// 施工单位
        /// </summary>
        [Required(ErrorMessage = "施工单位为必输")]
        public string ContructUnit { get; set; }

        /// <summary>
        /// 运营单位
        /// </summary>
        [Required(ErrorMessage = "运营单位为必输")]
        public string OperationUnit { get; set; }

        /// <summary>
        /// 最新养护合同起始日期
        /// </summary>
        [Required(ErrorMessage = "最新养护合同起始日期为必输")]
        public DateTime NewContractStartDate { get; set; }

        /// <summary>
        /// 最新养护合同结束日期
        /// </summary>
        [Required(ErrorMessage = "最新养护合同结束日期为必输")]
        public DateTime NewContractEndDate { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }

      
    }
}