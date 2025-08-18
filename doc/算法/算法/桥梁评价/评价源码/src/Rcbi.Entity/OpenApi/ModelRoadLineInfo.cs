using System;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 线路基本信息
    /// </summary>
    public class ModelRoadLineInfo
    {
        /// <summary>
        /// 线路名称
        /// </summary>
        [Required(ErrorMessage = "线路名称为必输")]
        public string LineName { get; set; }
        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必输")]
        public string LineCode { get; set; }
        /// <summary>
        /// 线路长度
        /// </summary>
        [Required(ErrorMessage = "线路长度为必输")]
        public decimal LineLength { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string Project_Code { get; set; }
        public string StructureType { get; set; }
        public int StructureTypeLength { get; set; }

        public DateTime? datapushdate { get; set; }
    }
}

