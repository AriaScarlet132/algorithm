using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 交通流量DTI线路业务信息
    /// </summary>
    public class ModelOpDtidataQuery : LayuiQuery
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
        /// 隧道日总流量
        /// </summary>
        public int TunneltrafficTotal { get; set; }

        /// <summary>
        /// 隧道最高流量（小时）
        /// </summary>
        public int TunneltrafficMax { get; set; }

        /// <summary>
        /// 隧道5:00-7:00两小时流量
        /// </summary>
        public int Tunneltraffic57 { get; set; }

        /// <summary>
        /// 隧道17:00-19:00两小时流量
        /// </summary>
        public int Tunneltraffic1719 { get; set; }

        /// <summary>
        /// 车道1编号
        /// </summary>
        public string Lane1 { get; set; }

        /// <summary>
        /// 车道1总流量（日）
        /// </summary>
        public int Lane1Trafficnum { get; set; }

        /// <summary>
        /// 车道1的5:00-7:00两小时流量
        /// </summary>
        public int Lane1Traffic57 { get; set; }

        /// <summary>
        /// 车道1的17:00-19:00两小时流量
        /// </summary>
        public int Lane1Traffic1719 { get; set; }

        /// <summary>
        /// 车道2编号
        /// </summary>
        public string Lane2 { get; set; }

        /// <summary>
        /// 车道2总流量（日）
        /// </summary>
        public int Lane2Trafficnum { get; set; }

        /// <summary>
        /// 车道2的5:00-7:00两小时流量
        /// </summary>
        public int Lane2Traffic57 { get; set; }

        /// <summary>
        /// 车道2的17:00-19:00两小时流量
        /// </summary>
        public int Lane2Traffic1719 { get; set; }

        /// <summary>
        /// 车道3编号
        /// </summary>
        public string Lane3 { get; set; }

        /// <summary>
        /// 车道3总流量（日）
        /// </summary>
        public int Lane3Trafficnum { get; set; }

        /// <summary>
        /// 车道3的5:00-7:00两小时流量
        /// </summary>
        public int Lane3Traffic57 { get; set; }

        /// <summary>
        /// 车道3的17:00-19:00两小时流量
        /// </summary>
        public int Lane3Traffic1719 { get; set; }

        /// <summary>
        /// 车道4编号
        /// </summary>
        public string Lane4 { get; set; }

        /// <summary>
        /// 车道4总流量（日）
        /// </summary>
        public int Lane4Trafficnum { get; set; }

        /// <summary>
        /// 车道4的5:00-7:00两小时流量
        /// </summary>
        public int Lane4Traffic57 { get; set; }

        /// <summary>
        /// 车道4的17:00-19:00两小时流量
        /// </summary>
        public int Lane4Traffic1719 { get; set; }

        /// <summary>
        /// 车道5编号
        /// </summary>
        public string Lane5 { get; set; }

        /// <summary>
        /// 车道5总流量（日）
        /// </summary>
        public int Lane5Trafficnum { get; set; }

        /// <summary>
        /// 车道5的5:00-7:00两小时流量
        /// </summary>
        public int Lane5Traffic57 { get; set; }

        /// <summary>
        /// 车道5的17:00-19:00两小时流量
        /// </summary>
        public int Lane5Traffic1719 { get; set; }

        /// <summary>
        /// 车道6编号
        /// </summary>
        public string Lane6 { get; set; }

        /// <summary>
        /// 车道6总流量（日）
        /// </summary>
        public int Lane61Trafficnum { get; set; }

        /// <summary>
        /// 车道6的5:00-7:00两小时流量
        /// </summary>
        public int Lane6Traffic57 { get; set; }

        /// <summary>
        /// 车道6的17:00-19:00两小时流量
        /// </summary>
        public int Lane6Traffic1719 { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }


        /// <summary>
        /// 观测年份 v2
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// 观测月份 v2
        /// </summary>
        public int? Month { get; set; }
        /// <summary>
        /// 高峰期平均每天车流量（4小时）(pcu/d)   v2
        /// </summary>
        public double? TrafficPeak4h { get; set; }
        /// <summary>
        /// 月度总车流量(pcu/m) v2
        /// </summary>
        public long? TrafficTotal { get; set; }
        /// <summary>
        /// 小客车月度总车流量 (pcu/m)   v2
        /// </summary>
        public long? MiniBus { get; set; }
        /// <summary>
        /// 大型客车月度总车流量(pcu/m)   v2
        /// </summary>
        public long? LargeBus { get; set; }
        /// <summary>
        /// 大型货车月度总车流量(pcu/m)   v2
        /// </summary>
        public long? LargeTruck { get; set; }
        /// <summary>
        /// 铰接车月度总车流量 (pcu/m)   v2
        /// </summary>
        public long? Articulated { get; set; }

    }
}