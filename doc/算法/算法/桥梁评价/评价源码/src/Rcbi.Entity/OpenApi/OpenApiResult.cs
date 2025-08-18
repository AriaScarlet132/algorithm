using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rcbi.Entity.OpenApi
{
    public class OpenApiResult<T>
    {
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

    }
}
