using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属子设施评价结果
    /// </summary>
    public class ModelAFResultCategory
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 子设施类别名称
        /// </summary>
        public string FacilityCategory_Name { get; set; }
        /// <summary>
        /// 子设施类别编码
        /// </summary>
        public string FacilityCategory_Code { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int ranks { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskNO { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// 权重值
        /// </summary>
        public decimal? weight_value { get; set; }

        /// <summary>
        /// 线路编码 V2
        /// </summary>
        public string LineCode { get; set; }
        
    }
}
