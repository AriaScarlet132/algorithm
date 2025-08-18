using System;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 路面检测单信息
    /// </summary>
    public class ModelRoadCheckUnitInfo
    {
        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必输")]
        public string line_no { get; set; }
        /// <summary>
        /// 车道号
        /// </summary>
        [Required(ErrorMessage = "车道号为必输")]
        public string lane_no { get; set; }
        /// <summary>
        /// 起点里程 km
        /// </summary>
        [Required(ErrorMessage = "起点里程为必输")]
        public decimal start_mileage { get; set; }
        /// <summary>
        /// 结束里程 km
        /// </summary>
        [Required(ErrorMessage = "结束里程为必输")]
        public decimal end_mileage { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 评价单元编号 v2
        /// </summary>
        public string section_code { get; set; }
        

    }
}

