using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 更新数据
    /// </summary>
    public class ModelAfFacilityUploadData
    {
        /// <summary>
        /// 附属设施清单
        /// </summary>
        public List<ModelAfFacilitylist> modelAfFacilitylists { get; set; }

        /// <summary>
        ///  附属子设施检查评分明细
        /// </summary>
        public List<ModelAfFacilityCheckValue> modelAfFacilityCheckValues { get; set; }
       
    }
}
