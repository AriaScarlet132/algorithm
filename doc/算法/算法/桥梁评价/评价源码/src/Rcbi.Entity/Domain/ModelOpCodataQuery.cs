using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// CO一氧化碳指数业务信息
    /// </summary>
    public class ModelOpCodataQuery : LayuiQuery
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
        /// 安装位置
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 里程桩号
        /// </summary>
        public string Mileage { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string MonitorYear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public string MonitorMonth { get; set; }

        /// <summary>
        /// 检测值
        /// </summary>
        public decimal MonitorData { get; set; }

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