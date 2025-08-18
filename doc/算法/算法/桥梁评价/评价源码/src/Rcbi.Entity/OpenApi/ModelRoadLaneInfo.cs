using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 车道基本信息
    /// </summary>
    public class ModelRoadLaneInfo
    {
        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必输")]
        public string LineCode { get; set; }
        /// <summary>
        /// 车道号
        /// </summary>
        [Required(ErrorMessage = "车道号为必输")]
        public string LaneCode { get; set; }
        /// <summary>
        /// 车道宽度
        /// </summary>
        [Required(ErrorMessage = "车道宽度为必输")]
        public decimal LaneWidth { get; set; }
        /// <summary>
        /// 车道长度
        /// </summary>
        [Required(ErrorMessage = "车道长度为必输")]
        public decimal LaneLength { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注为必输")]
        public string Memo { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string Project_Code { get; set; }

    }
}
