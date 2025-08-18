using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelTjWeights
    {

        /// <summary>
        /// 结构属性
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public decimal Weight_Att { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public decimal Weight_Type { get; set; }

        /// <summary>
        /// 构件类型
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// 构件类型权重
        /// </summary>
        public decimal Weight_Com { get; set; }

        /// <summary>
        /// 病害项
        /// </summary>
        public string Defect { get; set; }

        /// <summary>
        /// 病害项权重
        /// </summary>
        public decimal Weight_Def { get; set; }

        /// <summary>
        /// 病害重要程度
        /// </summary>
        public string Defect_importance { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }
    }
}