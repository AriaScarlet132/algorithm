using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属设施类别及权重
    /// </summary>
    public class ModelAFTypeWeight
    {
        /// <summary>
        /// 设施类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 设施类型编码
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 设施类型权重
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 父设施类别
        /// </summary>
        public string ParentType { get; set; }
        /// <summary>
        /// 设施类型重要度
        /// </summary>
        public string Importance { get; set; }
        /// <summary>
        /// 设施类型层级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string facility_type { get; set; }
    }
}
