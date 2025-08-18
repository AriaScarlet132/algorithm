using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属设施结果
    /// </summary>
    public class ModelAfInfos
    {
        /// <summary>
        /// 附属设施总体评价结果
        /// </summary>
        public ModelAFResult ModelAFResult { get; set; }

        /// <summary>
        /// 附属子设施评价结果
        /// </summary>
        public IList<ModelAFResultCategory> ModelAFResultCategorys { get; set; }

        /// <summary>
        /// 附属分设施评价结果
        /// </summary>
        public IList<ModelAFResultType> ModelAFResultTypes { get; set; }


        /// <summary>
        ///  附属分设施评价结果 v2 
        /// </summary>
        public IList<ModelAFResultLine> ModelAFResultLines { get; set; }

    }
}
