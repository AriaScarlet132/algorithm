using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 噪音DI业务信息
    /// </summary>
    public class ModelOpDidataQuery : LayuiQuery
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
        /// 月份-白天
        /// </summary>
        public string MonitorMonthDay { get; set; }

        /// <summary>
        /// 检测值1
        /// </summary>
        public decimal MonitorDataDay { get; set; }

        /// <summary>
        /// 月份-晚上
        /// </summary>
        public string MonitorMonthNight { get; set; }

        /// <summary>
        /// 检测值2
        /// </summary>
        public decimal MonitorDataNight { get; set; }

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