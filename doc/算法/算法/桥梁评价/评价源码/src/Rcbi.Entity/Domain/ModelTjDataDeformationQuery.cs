using Rcbi.Entity.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class ModelTjDataDeformationQuery : LayuiQuery
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string task_no { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// 测点编号
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 里程号
        /// </summary>
        public string station { get; set; }

        /// <summary>
        /// 变量
        /// </summary>
        public string valueName { get; set; }

        /// <summary>
        /// 变量编号
        /// </summary>
        public string valueCode { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public decimal? deformationValue { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}
