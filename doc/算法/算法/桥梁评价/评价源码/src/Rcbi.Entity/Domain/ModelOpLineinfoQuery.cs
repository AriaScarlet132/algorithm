using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 隧道线路基本业务信息
    /// </summary>
    public class ModelOpLineinfoQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 线路长度
        /// </summary>
        public decimal LineLength { get; set; }

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

        /// <summary>
        /// 结构区段  V2
        /// </summary>
        public string StructureType { get; set; }
        /// <summary>
        /// 结构区段长度   V2
        /// </summary>
        public int? StructureTypeLength { get; set; }
    }
}