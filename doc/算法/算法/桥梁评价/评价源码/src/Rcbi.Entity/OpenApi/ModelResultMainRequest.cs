using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelResultMainRequest
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime datasource_startdate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime datasource_enddate { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Project_Code { get; set; }
        /// <summary>
        /// 设施类型
        /// </summary>
        public string facility_type { get; set; }
        /// <summary>
        /// 回调接口
        /// </summary>
        public string callback_url { get; set; }
     
    }
}
