using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 车道信息
    /// </summary>
    public class ModelTjLine
    {

        /// <summary>
        /// 线路名
        /// </summary>
        public string Line_name { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必须")]
        public string Line_no { get; set; }

        /// <summary>
        /// 线路长
        /// </summary>
        [Required(ErrorMessage = "线路长为必须")]
        public decimal Line_l { get; set; }

        /// <summary>
        /// 项目编码
        /// </summary>
        [Required(ErrorMessage = "项目编码为必须")]
        public string Project_Code { get; set; }
    }
}