using System;
using System.Collections.Generic;

namespace Rcbi.Core
{
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T> 
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            if (pageSize == 0) {
                TotalPages=0;
            }
            else
            {
                TotalPages = TotalCount / pageSize;
                if (TotalCount % pageSize > 0)
                    TotalPages++;
            }
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(items);
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
