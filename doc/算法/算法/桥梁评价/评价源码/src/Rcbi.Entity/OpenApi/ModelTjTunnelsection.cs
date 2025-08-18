using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 设施单元结构信息
    /// </summary>
    public class ModelTjTunnelsection
    {
        /// <summary>
        /// 管理单元
        /// </summary>
        [Required(ErrorMessage = "管理单元为必须")]
        public string ManagementUnit { get; set; }

        /// <summary>
        /// 结构区段
        /// </summary>
        [Required(ErrorMessage = "结构区段为必须")]
        public string StructureSection { get; set; }

        /// <summary>
        /// 隧道线路
        /// </summary>
        [Required(ErrorMessage = "隧道线路为必须")]
        public string Line { get; set; }

        /// <summary>
        /// 结构属性（大类）
        /// </summary>
        [Required(ErrorMessage = "结构属性为必须")]
        public string StructureAtt { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        [Required(ErrorMessage = "结构类别为必须")]
        public string StructureType { get; set; }

        /// <summary>
        /// 评价单元编码
        /// </summary>
        [Required(ErrorMessage = "评价单元编码为必须")]
        public string Code_Section { get; set; }

        /// <summary>
        /// 起里程号
        /// </summary>
        [Required(ErrorMessage = "起里程号为必须")]
        public string Start_mileage { get; set; }

        /// <summary>
        /// 止里程号
        /// </summary>
        [Required(ErrorMessage = "止里程号为必须")]
        public string End_mileage { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }
    }
}