using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 结构类别信息
    /// </summary>
    public class ModelTjTunnelstructuretype
    {


        /// <summary>
        /// 隧道线路
        /// </summary>
        [Required(ErrorMessage = "隧道线路为必须")]
        public string Line { get; set; }

        /// <summary>
        /// 线路编码
        /// </summary>
        [Required(ErrorMessage = "线路编码为必须")]
        public string Code_line { get; set; }

        /// <summary>
        /// 结构属性
        /// </summary>
        [Required(ErrorMessage = "结构属性为必须")]
        public string StructureAtt { get; set; }

        /// <summary>
        /// 结构属性编码
        /// </summary>
        [Required(ErrorMessage = "结构属性编码为必须")]
        public string Code_StructureAtt { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        [Required(ErrorMessage = "结构类别为必须")]
        public string StructureType { get; set; }

        /// <summary>
        /// 结构类别编码
        /// </summary>
        [Required(ErrorMessage = "结构类别编码为必须")]
        public string Code_StructureType { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }
    }
}