using System;
using System.Collections.Generic;

namespace Rcbi.Entity.Query
{
    public abstract class LayuiQuery
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public string SortField { get; set; }

        public string SortDir { get; set; }

        public CommonQuery Create()
        {
            return new CommonQuery()
            {
                PageIndex = Page,
                PageSize = Limit,
                Filters = new List<Filter>(),
                SortField = SortField,
                SortDir = SortDir == "desc" ? Entity.SortDir.Desc : Entity.SortDir.Asc
            };
        }

        public abstract CommonQuery ToCommonQuery();
    }
}
