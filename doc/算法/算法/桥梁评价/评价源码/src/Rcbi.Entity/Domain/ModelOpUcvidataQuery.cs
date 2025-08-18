using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 用户满意度UCVI业务信息
    /// </summary>
    public class ModelOpUcvidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string DataYear { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public string DataMonth { get; set; }

        /// <summary>
        /// n（来信、来访、来电未及时处置数）
        /// </summary>
        public string DelayAmount { get; set; }

        /// <summary>
        /// n（来信、来访、来电应处置数）
        /// </summary>
        public decimal HandleAmount { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }

        /// <summary>
        /// 有责投诉数  V2
        /// </summary>
        public int? Nr { get; set; }
        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}