using System;

using Rcbi.Core.Extensions;


namespace Rcbi.Entity.Query
{
    public class SystemLogQuery : LayuiQuery
    {
        public string RealName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string LogType { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            var query = this.Create();

            if (!RealName.IsNullOrEmpty())
                query.Filters.Add(new Filter() { Filed = "b.real_name", Op = "like", Data = RealName });
            if (!LogType.IsNullOrEmpty())
                query.Filters.Add(new Filter() { Filed = "a.log_type", Op = "=", Data = LogType });
            if (StartDate.HasValue)
                query.Filters.Add(new Filter() { Filed = "a.create_date", Op = ">=", Data = StartDate.Value.ToString("yyyy-MM-dd") });
            if (EndDate.HasValue)
                query.Filters.Add(new Filter() { Filed = "a.create_date", Op = "<=", Data = EndDate.Value.ToString("yyyy-MM-dd") });

            return query;
        }
    }
}