using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 评价单元信息
    /// </summary>
    public class ModelTjDataStructurefacility
    {

        /// <summary>
        /// 设施编码
        /// </summary>
        [Required(ErrorMessage = "设施编码为必须")]
        public string Code { get; set; }

        /// <summary>
        /// 设施名称
        /// </summary>
        [Required(ErrorMessage = "设施名称为必须")]
        public string Name { get; set; }

        /// <summary>
        /// 管理单元
        /// </summary>
        [Required(ErrorMessage = "管理单元为必须")]
        public string ManagementUnit { get; set; }

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
        /// 构件类型（小类）
        /// </summary>
        [Required(ErrorMessage = "构件类型为必须")]
        public string ComponentType { get; set; }

        /// <summary>
        /// 起里程号
        /// </summary>
        [Required(ErrorMessage = "起里程号为必须")]
        public string Start_Mileage { get; set; }

        /// <summary>
        /// 止里程号
        /// </summary>
        [Required(ErrorMessage = "止里程号为必须")]
        public string End_Mileage { get; set; }

        /// <summary>
        /// 对应评价单元编码
        /// </summary>
        [Required(ErrorMessage = "对应评价单元编码为必须")]
        public string Code_Section { get; set; }

        /// <summary>
        /// 项目编码
        /// </summary>
        [Required(ErrorMessage = "项目编码为必须")]
        public string Project_Code { get; set; }


        /// <summary>
        /// 隧道线路 v2
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 结构类别  v2
        /// </summary>
        public string SectionName { get; set; }
        /// <summary>
        /// 评价单元编码  v2
        /// </summary>
        public string SectionCode { get; set; }
        /// <summary>
        /// 构件类型编码   v2
        /// </summary>
        public string ComponentCode { get; set; }
    }
}