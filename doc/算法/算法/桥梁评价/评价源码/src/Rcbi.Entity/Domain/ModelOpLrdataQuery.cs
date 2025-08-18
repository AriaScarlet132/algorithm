using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 交通路面荷载LR业务信息
    /// </summary>
    public class ModelOpLrdataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 观测日期
        /// </summary>
        public DateTime MonitorDate { get; set; }

        /// <summary>
        /// 车辆数
        /// </summary>
        public int TotalCar { get; set; }

        /// <summary>
        /// 小型车数
        /// </summary>
        public int SmallCarAmount { get; set; }

        /// <summary>
        /// 大型车数
        /// </summary>
        public int BigCarAmount { get; set; }

        /// <summary>
        /// 中型车数
        /// </summary>
        public int MediumCarAmount { get; set; }

        /// <summary>
        /// 集卡数
        /// </summary>
        public int TruckAmount { get; set; }

        /// <summary>
        /// 客车1数
        /// </summary>
        public int BusAmount1 { get; set; }

        /// <summary>
        /// 客车2数
        /// </summary>
        public int BusAmount2 { get; set; }

        /// <summary>
        /// 客车3数
        /// </summary>
        public int BusAmount3 { get; set; }

        /// <summary>
        /// 客车4数
        /// </summary>
        public int BusAmount4 { get; set; }

        /// <summary>
        /// 货车1数
        /// </summary>
        public int VanAmount1 { get; set; }

        /// <summary>
        /// 货车2数
        /// </summary>
        public int VanAmount2 { get; set; }

        /// <summary>
        /// 货车3数
        /// </summary>
        public int VanAmount3 { get; set; }

        /// <summary>
        /// 货车4数
        /// </summary>
        public int VanAmount4 { get; set; }

        /// <summary>
        /// 货车5数
        /// </summary>
        public int VanAmount5 { get; set; }

        /// <summary>
        /// 集卡1数
        /// </summary>
        public int TruckAmount1 { get; set; }

        /// <summary>
        /// 集卡2数
        /// </summary>
        public int TruckAmount2 { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}