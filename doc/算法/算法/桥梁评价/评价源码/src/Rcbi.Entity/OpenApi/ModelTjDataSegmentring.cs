using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 项目的环号信息
    /// </summary>
    public class ModelTjDataSegmentring
    {
        /// <summary>
        /// 线路
        /// </summary>
        [Required(ErrorMessage = "线路为必须")]
        public string Line { get; set; }

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
        /// 对应管片环号
        /// </summary>
        [Required(ErrorMessage = "对应管片环号为必须")]
        public int RingNumber { get; set; }

        /// <summary>
        /// 起始里程
        /// </summary>
        [Required(ErrorMessage = "起始里程为必须")]
        public string Start_Mileage { get; set; }

        /// <summary>
        /// 结束里程
        /// </summary>
        [Required(ErrorMessage = "结束里程为必须")]
        public string End_Mileage { get; set; }

        /// <summary>
        /// 对应评价单元编码
        /// </summary>
        [Required(ErrorMessage = "对应评价单元编码为必须")]
        public string Section { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编码为必须")]
        public string Project_Code { get; set; }
    }
}