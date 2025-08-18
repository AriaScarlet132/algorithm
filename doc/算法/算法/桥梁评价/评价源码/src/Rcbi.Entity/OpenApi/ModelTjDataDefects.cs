using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 结构缺陷信息
    /// </summary>
    public class ModelTjDataDefects
    {

        /// <summary>
        /// 时间
        /// </summary>
        [Required(ErrorMessage = "时间为必须")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// 线路
        /// </summary>
        [Required(ErrorMessage = "线路号为必须")]
        public string Line { get; set; }

        /// <summary>
        /// 结构区段
        /// </summary>
        [Required(ErrorMessage = "结构区段为必须")]
        public string StructureSection { get; set; }

        /// <summary>
        /// 管理单元名称
        /// </summary>
        [Required(ErrorMessage = "管理单元名称为必须")]
        public string ManagementUnit { get; set; }

        /// <summary>
        /// 结构属性
        /// </summary>
        [Required(ErrorMessage = "结构属性为必须")]
        public string StructureAtt { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        [Required(ErrorMessage = "结构类别为必须")]
        public string StructureType { get; set; }

        /// <summary>
        /// 构件类型
        /// </summary>
        [Required(ErrorMessage = "构件类型为必须")]
        public string ComponentType { get; set; }

        /// <summary>
        /// 里程桩号
        /// </summary>
        [Required(ErrorMessage = "里程桩号为必须")]
        public string Mileage { get; set; }

        /// <summary>
        /// 病害类型
        /// </summary>
        public string Defect { get; set; }

        /// <summary>
        /// 病害形态
        /// </summary>
        public string DefectType { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        [Required(ErrorMessage = "严重程度为必须")]
        public string DefectSeverity { get; set; }

        /// <summary>
        /// 病害描述
        /// </summary>
        public string DefectDescription { get; set; }

        /// <summary>
        /// 管片环号
        /// </summary>
        public string RingNumber { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必须")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 评价单元名称
        /// </summary>
        public string SectionName { get; set; }
        /// <summary>
        /// 评价单元编码
        /// </summary>
        public string SectionCode { get; set; }
    }
}