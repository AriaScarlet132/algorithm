using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属分设施评价结果
    /// </summary>
    public class ModelAFResultType
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 设施类型
        /// </summary>
        public string  FacilityType_Name { get; set; }
        /// <summary>
        /// 设施类型编码
        /// </summary>
        public string FacilityType_Code { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public decimal Value { get; set; }
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

        public string LineCode { get; set; }
    }
}
