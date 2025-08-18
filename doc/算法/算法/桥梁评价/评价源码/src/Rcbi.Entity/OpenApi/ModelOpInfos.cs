using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务结果
    /// </summary>
   public class ModelOpInfos
    {
        /// <summary>
        /// 运营服务FWCI总体评价结果
        /// </summary>
        public ModelOpResultAll ModelOpResultAll { get; set; }

        /// <summary>
        /// 运营服务分类项目评价结果
        /// </summary>
        public ModelOpResultClassification ModelOpResultClassification { get; set; }

        /// <summary>
        /// 运营服务用户服务类指标CSI评价结果
        /// </summary>
        public ModelOpResultCsi ModelOpResultCsi { get; set; }
        /// <summary>
        /// 运营服务内业管理类指标MSI评价结果
        /// </summary>
        public ModelOpResultMsi ModelOpResultMsi { get; set; }
        /// <summary>
        /// 运营服务交通服务类指标Tsi评价结果
        /// </summary>
        public ModelOpResultTsi ModelOpResultTsi { get; set; }
        /// <summary>
        /// 运营服务安全服务类指标SSI评价结果
        /// </summary>
        public ModelOpResultSsi ModelOpResultSsi { get; set; }

        /// <summary>
        /// 运营服务子指标评价结果
        /// </summary>
        public ModelOpResultIndexevaluation ModelOpResultIndexevaluation { get; set; }

        /// <summary>
        /// 运营服务分类项目评价结果
        /// </summary>
        public ModelOpResultMidevaluation ModelOpResultMidevaluation { get; set; }


    }
}
