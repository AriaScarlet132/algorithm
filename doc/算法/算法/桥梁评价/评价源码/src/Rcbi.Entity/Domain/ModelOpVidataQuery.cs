using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 能见度VI业务信息
    /// </summary>
    public class ModelOpVidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string project_code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string task_no { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        public string linecode { get; set; }

        /// <summary>
        /// 安装位置
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// 里程桩号
        /// </summary>
        public string mileage { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string deviceno { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int monitoryear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public int monitormonth { get; set; }

        /// <summary>
        /// 检测值
        /// </summary>
        public decimal monitordata { get; set; }


        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}