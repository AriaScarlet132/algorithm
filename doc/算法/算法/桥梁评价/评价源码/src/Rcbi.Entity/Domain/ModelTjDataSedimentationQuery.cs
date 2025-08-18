using Rcbi.Entity.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class ModelTjDataSedimentationQuery : LayuiQuery
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string task_no { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? start_date { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? end_date { get; set; }

        /// <summary>
        /// 桩号
        /// </summary>
        public string station { get; set; }

        /// <summary>
        /// 编号-R
        /// </summary>
        public string Code_R { get; set; }

        /// <summary>
        /// 初始值-R
        /// </summary>
        public string Value_R { get; set; }

        /// <summary>
        /// 编号-L
        /// </summary>
        public string Code_L { get; set; }

        /// <summary>
        /// 初始值-L
        /// </summary>
        public string Value_L { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }

        public string Code { get; set; }
        public decimal? Value { get; set; }
        public decimal? Sedimentation { get; set; }
    }
}
