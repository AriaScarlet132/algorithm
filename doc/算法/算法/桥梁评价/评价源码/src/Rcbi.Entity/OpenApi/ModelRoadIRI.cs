using System;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 监测指标数据
    /// </summary>
    public class ModelRoadIRI
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
        /// 起点里程 km
        /// </summary>
        [Required(ErrorMessage = "起点里程为必须")]
        [Range(0.01, 100.00, ErrorMessage = "起点里程有效范围[0.01-100.00]")]
        public decimal? start_mileage { get; set; }

        /// <summary>
        /// 结束里程 km
        /// </summary>
        [Required(ErrorMessage = "结束里程为必须")]
        [Range(0.01, 100.00, ErrorMessage = "结束里程有效范围[0.01-100.00]")]
        public decimal? end_mileage { get; set; }

        /// <summary>
        /// 平整度
        /// </summary>
        [Required(ErrorMessage = "平整度为必须")]
        [Range(0.01, 100.00, ErrorMessage = "平整度有效范围[0.01-100.00]")]
        public decimal? iri { get; set; }

        /// <summary>
        /// 车辙
        /// </summary>
        [Required(ErrorMessage = "车辙为必须")]
        [Range(0.01, 100.00, ErrorMessage = "车辙有效范围[0.01-100.00]")]
        public decimal? rd { get; set; }

        /// <summary>
        /// 抗滑
        /// </summary>
        public decimal? bpn { get; set; }

        /// <summary>
        /// 弯沉
        /// </summary>
        public decimal? L0 { get; set; }

        /// <summary>
        /// 基层类型
        /// </summary>
        public string basement { get; set; }

        /// <summary>
        /// 交通量型
        /// </summary>
        public string volume { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskNo { get; set; }

    }
}

