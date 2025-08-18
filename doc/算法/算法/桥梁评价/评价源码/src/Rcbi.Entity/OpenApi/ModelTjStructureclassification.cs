using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelTjStructureclassification
    {

        /// <summary>
        /// 结构属性
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// 结构类型
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// 构件类型
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// 构件重要度
        /// </summary>
        public string Component_importance { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// 权重V2
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 病害项V2
        /// </summary>
        public string  Defect { get; set; }
    }
}