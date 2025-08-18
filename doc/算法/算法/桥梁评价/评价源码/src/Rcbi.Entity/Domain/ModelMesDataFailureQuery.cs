using Rcbi.Entity.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class ModelMesDataFailureQuery : LayuiQuery
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 时间 年-月-日
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 任务编号
        /// </summary>
        public string task_no { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string project_name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int delete_flag { get; set; }
        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}
