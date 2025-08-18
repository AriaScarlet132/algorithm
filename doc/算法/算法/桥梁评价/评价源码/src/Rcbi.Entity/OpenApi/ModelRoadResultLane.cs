using Rcbi.Core.Attributes;
using System;
namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 隧道车道级路面评价结果
    /// </summary>
    public class ModelRoadResultLane
    { 
        /// <summary>
        /// 流水号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string line_no { get; set; }
        /// <summary>
        /// 车道编号
        /// </summary>
        public string lane_no { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime start { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime end { get; set; }
        /// <summary>
        /// rqi值
        /// </summary>
        public decimal rqi { get; set; }
        /// <summary>
        /// rdi值
        /// </summary>
        public decimal rdi { get; set; }
        /// <summary>
        /// pci值
        /// </summary>
        public decimal pci { get; set; }
        /// <summary>
        /// sri值
        /// </summary>
        public decimal sri { get; set; }
        /// <summary>
        /// pssi值
        /// </summary>
        public decimal pssi { get; set; }
        /// <summary>
        /// pqi值
        /// </summary>
        public decimal pqi { get; set; }
        /// <summary>
        /// sci值
        /// </summary>
        public decimal sci { get; set; }
        /// <summary>
        /// mqi值
        /// </summary>
        public decimal mqi { get; set; }
        /// <summary>
        /// rci值
        /// </summary>
        public decimal rci { get; set; }      
        /// <summary>
        /// iri等级
        /// </summary>
        public string iri_level { get; set; }
        /// <summary>
        /// rqi等级
        /// </summary>
        public string rqi_level { get; set; }
        /// <summary>
        /// rdi等级
        /// </summary>
        public string rdi_level { get; set; }
        /// <summary>
        /// pci等级
        /// </summary>
        public string pci_level { get; set; }
        /// <summary>
        /// sri等级
        /// </summary>
        public string sri_level { get; set; }
        /// <summary>
        /// pssi等级
        /// </summary>
        public string pssi_level { get; set; }
        /// <summary>
        /// pqi等级
        /// </summary>
        public string pqi_level { get; set; }
        /// <summary>
        /// sci等级
        /// </summary>
        public string sci_level { get; set; }
        /// <summary>
        /// mqi等级
        /// </summary>
        public string mqi_level { get; set; }
        /// <summary>
        /// rci等级
        /// </summary>
        public string rci_level { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }

    }
}

