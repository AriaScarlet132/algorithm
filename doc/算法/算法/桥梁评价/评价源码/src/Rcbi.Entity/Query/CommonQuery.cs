using System;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;

using Newtonsoft.Json;
using Rcbi.Core.Extensions;
using Rcbi.AspNetCore.Helper;

namespace Rcbi.Entity.Query
{
    /// <summary>
    /// 通用查询类
    /// </summary>
    public class CommonQuery : BaseQueryEntity
    {
        /// <summary>
        /// 过滤条件
        /// </summary>
        [JsonProperty("filters")]
        public IList<Filter> Filters { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [JsonProperty("orders")]
        public string Orders { get; set; }

        /// <summary>
        /// 扩展条件
        /// </summary>
        [JsonProperty("external")]
        public string External { get; set; }

        /// <summary>
        /// 创建where条件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="whereString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool Where(DbHelper helper, out string whereString, out IList<DbParameter> parameters)
        {
            if (!this.Filters.IsExists() &&
                 this.External.IsNullOrEmpty()) {
                whereString = string.Empty;
                parameters = null;
                return false;
            }

            var whereBuilder = new StringBuilder();
            parameters = new List<DbParameter>();

            if (this.Filters.IsExists())
            {
                for (var i = 0; i < this.Filters.Count; i++)
                {
                    whereBuilder.Append(" AND ");

                    whereBuilder.AppendLine()
                      .Append(this.Filters[i].ToString());

                    parameters.Add(
                        helper.CreateParameter("@" + this.Filters[i].ParaString,
                        this.Filters[i].Data));
                }
            }

            if (!this.External.IsNullOrEmpty())
            {
                whereBuilder.AppendFormat(" AND ({0})", this.External);
            }

            whereString = whereBuilder.ToString();

            return true;
        }
    }

    /// <summary>
    /// 过滤操作类
    /// </summary>
    public class Filter
    {
        private static IDictionary<string, bool> ops = new Dictionary<string, bool>();

        static Filter()
        {
            ops.Add("like", true);
            ops.Add(">", true);
            ops.Add(">=", true);
            ops.Add("<", true);
            ops.Add("<=", true);
            ops.Add("=", true);
        }
        private string _ParaString;

        [JsonProperty("field")]
        public string Filed { get; set; }

        public string ParaString
        {
            get
            {
                if (_ParaString.IsNullOrEmpty())
                    _ParaString = Guid.NewGuid().ToString("N");
                return _ParaString;
            }
        }
        /// <summary>
        /// 操作符
        /// </summary>
        [JsonProperty("op")]
        public string Op { get; set; }

        /// <summary>
        /// 过滤数据
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        public override string ToString()
        {
            if (this.Op.IsNullOrEmpty() ||
                !ops.ContainsKey(this.Op) ||
                this.Data.IsNullOrEmpty())
                return string.Empty;

            if (!this.Data.IsNullOrEmpty())
            {
                if (this.Op == "like")
                {
                    this.Data = "%" + this.Data + "%";
                }
            }
            return string.Format("{0} {1} @{2}", this.Filed, Op, ParaString);
        }
    }

    public static class Extensions
    {
        public static bool IsExists(this IList<Filter> target)
        {
            return target != null && target.Count > 0;
        }
    }
}
