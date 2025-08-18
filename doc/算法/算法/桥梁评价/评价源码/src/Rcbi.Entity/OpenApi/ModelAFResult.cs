using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属设施总体评价结果
    /// </summary>
    public class ModelAFResult
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        public string TaskNO { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }
    }
}
