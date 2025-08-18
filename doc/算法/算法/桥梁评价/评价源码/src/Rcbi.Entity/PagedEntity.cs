using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Rcbi.Entity
{
    /// <summary>
    /// 分页实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePagedEntity<T>  where T : BaseModelEntity
    {
        private List<T> Datas = new List<T>();

        public BasePagedEntity(IEnumerable<T> items, int pageIndex, int pageSize, int totalCount) 
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Datas.AddRange(items);
        }
        [JsonProperty("PageIndex")]
        public int PageIndex { get; set; }
        [JsonProperty("PageSize")]
        public int PageSize { get; set; }
        [JsonProperty("TotalCount")]
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
        public List<T> Items 
        {
            get { return this.Datas; }
        }
    }
}
