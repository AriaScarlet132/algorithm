using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属子设施量汇总
    /// </summary>
    public class ModelAFFacilityNum
    {
        /// <summary>
        /// 子设施类型名称
        /// </summary>
        public string FacilityCategory_Name { get; set; }
        /// <summary>
        /// 子设施类型编码
        /// </summary>
        public string FacilityCategory_Code { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }
    }
}
