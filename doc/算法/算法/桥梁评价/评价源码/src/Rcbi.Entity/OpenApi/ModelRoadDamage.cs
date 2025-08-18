using System;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 路面病害数据
    /// </summary>
    public class ModelRoadDamage
    {
        /// <summary>
        /// 时间 年-月-日
        /// </summary>
        [Required(ErrorMessage = "时间为必须")]
        public DateTime? date { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        [Required(ErrorMessage = "线路号为必须")]
        public string line_no { get; set; }

        /// <summary>
        /// 车道号
        /// </summary>
        [Required(ErrorMessage = "车道号为必须")]
        public string lane_no { get; set; }

        /// <summary>
        /// 距离 km
        /// </summary>
        public decimal? dis { get; set; }

        /// <summary>
        /// 桩号 km
        /// </summary>
        public decimal? pnt { get; set; }

        /// <summary>
        /// 病害类型
        /// </summary>
        [Required(ErrorMessage = "病害类型为必须")]
        public string catalog { get; set; }

        /// <summary>
        /// 病害名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        [Required(ErrorMessage = "严重程度为必须")]
        public string severity { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// 病害区域宽度 m
        /// </summary>
        public decimal? width { get; set; }

        /// <summary>
        /// 病害区域长度 m
        /// </summary>
        [Required(ErrorMessage = "病害区域长度为必须")]
        public decimal? length { get; set; }

        /// <summary>
        /// 病害区域深度 mm
        /// </summary>
        public decimal? depth { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskNo { get; set; }


        /// <summary>
        /// 评价单元编号v2
        /// </summary>
        public string section_code { get; set; }
        /// <summary>
        /// 起始里程v2
        /// </summary>
        public string start_mileage { get; set; }
        /// <summary>
        /// 结束里程 v2
        /// </summary>
        public string end_mileage { get; set; }
    }
}

