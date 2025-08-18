using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属设施检查评分标准
    /// </summary>
    public class ModelAFFacilityMarkSpec
    {

        /// <summary>
        /// 子设施类别
        /// </summary>
        public string FacilityCategory_Name { get; set; }
        /// <summary>
        /// 子设施类别编码
        /// </summary>
        public string FacilityCategory_Code { get; set; }
        /// <summary>
        /// 状况值
        /// </summary>
        public int FacilityMark { get; set; }
        /// <summary>
        /// 技术状况描述
        /// </summary>
        public string FacilityStatusDesp { get; set; }
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
