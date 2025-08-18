using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 隧道车道基本业务信息
    /// </summary>
    public class ModelOpLaneinfoQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 车道号
        /// </summary>
        public string LaneCode { get; set; }

        /// <summary>
        /// 车道宽度
        /// </summary>
        public decimal LaneWidth { get; set; }

        /// <summary>
        /// 车道长度
        /// </summary>
        public decimal LaneLength { get; set; }

        public string project_code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

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