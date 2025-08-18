using Rcbi.Entity.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class ModelTjDataDefectsQuery : LayuiQuery
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string task_no { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 线路
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// 结构区段
        /// </summary>
        public string StructureSection { get; set; }

        /// <summary>
        /// 管理单元名称
        /// </summary>
        public string ManagementUnit { get; set; }

        /// <summary>
        /// 结构属性
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// 构件类型
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// 里程桩号
        /// </summary>
        public string Mileage { get; set; }

        /// <summary>
        /// 病害类型
        /// </summary>
        public string Defect { get; set; }

        /// <summary>
        /// 病害形态
        /// </summary>
        public string DefectType { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        public string DefectSeverity { get; set; }

        /// <summary>
        /// 病害描述
        /// </summary>
        public string DefectDescription { get; set; }

        /// <summary>
        /// 管片环号
        /// </summary>
        public string RingNumber { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 评价单元名称
        /// </summary>
        public string SectionName { get; set; }
        /// <summary>
        /// 评价单元编码
        /// </summary>
        public string SectionCode { get; set; }
        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }

    }
}
