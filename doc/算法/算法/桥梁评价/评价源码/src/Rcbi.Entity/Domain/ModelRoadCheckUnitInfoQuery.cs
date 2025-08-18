using Rcbi.Entity.Query;
using System;
namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 路面检测单信息
    /// </summary>
    public class ModelRoadCheckUnitInfoQuery : LayuiQuery
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        public string task_no { get; set; }
        /// <summary>
        /// 线路号
        /// </summary>
        public string line_no { get; set; }
        /// <summary>
        /// 车道号
        /// </summary>
        public string lane_no { get; set; }
        /// <summary>
        /// 起点里程 km
        /// </summary>
        public decimal start_mileage { get; set; }
        /// <summary>
        /// 结束里程 km
        /// </summary>
        public decimal end_mileage { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 项目名
        /// </summary>
        public string project_name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_flag { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}

