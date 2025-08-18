using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 待评价项目的构件类别得分计算信息
    /// </summary>
    public class ModelTjResultComponenttype
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 线路
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// 结构区段
        /// </summary>
        public string StructureSection { get; set; }

        /// <summary>
        /// 结构属性
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// 评价单元
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// 构件类型
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// 构件重要度
        /// </summary>
        public string Component_Importance { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// 评价单元编码v2
        /// </summary>
        public string section_code { get; set; }
    }
}