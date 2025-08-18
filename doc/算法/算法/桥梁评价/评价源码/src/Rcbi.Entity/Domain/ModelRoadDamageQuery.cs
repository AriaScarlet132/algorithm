using Rcbi.Entity.Query;
using System;
namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 路面病害数据
    /// </summary>
    public class ModelRoadDamageQuery : LayuiQuery
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 时间 年-月-日
        /// </summary>
        public DateTime date { get; set; }
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
        /// 距离 km
        /// </summary>
        public decimal dis { get; set; }
        /// <summary>
        /// 桩号 km
        /// </summary>
        public decimal pnt { get; set; }
        /// <summary>
        /// 病害类型
        /// </summary>
        public string catalog { get; set; }
        /// <summary>
        /// 病害名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 严重程度
        /// </summary>
        public string severity { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 病害区域宽度 m
        /// </summary>
        public decimal width { get; set; }
        /// <summary>
        /// 病害区域长度 m
        /// </summary>
        public decimal length { get; set; }
        /// <summary>
        /// 病害区域深度 mm
        /// </summary>
        public decimal depth { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 项目名称
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

