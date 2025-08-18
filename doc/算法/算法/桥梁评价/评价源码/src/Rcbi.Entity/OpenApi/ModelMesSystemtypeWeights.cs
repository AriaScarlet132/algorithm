using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelMesSystemtypeWeights
    {
        public int Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Column("CODE")]
        public string CODE { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [Column("SystemName")]
        public string SystemName { get; set; }

        /// <summary>
        /// 分系统占总体的权重
        /// </summary>
        [Column("weights_system")]
        public string WeightsSystem { get; set; }

        /// <summary>
        /// 父级系统
        /// </summary>
        [Column("ParentSystem")]
        public string ParentSystem { get; set; }

        /// <summary>
        /// 系统层级
        /// </summary>
        [Column("LevelName")]
        public string LevelName { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string facility_type { get; set; }
    }
}