using Rcbi.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Query
{
    public class TbModelResultMainQuery : LayuiQuery
    {
        public string taskno { get; set; }
        public string model_type { get; set; }
        public string projectid { get; set; }
        public string model_status { get; set; }
        public string facility_type { get; set; }
        public DateTime datasource_startdate { get; set; }
        public DateTime datasource_enddate { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            var query = this.Create();
            if (!taskno.IsNullOrEmpty())
                query.External = string.Format("and taskno like '%{0}%' ", taskno);
            if (!model_type.IsNullOrEmpty())
                query.Filters.Add(new Filter { Filed = "model_type", Op = "=", Data = model_type });
            if (!projectid.IsNullOrEmpty())
                query.Filters.Add(new Filter { Filed = "ProjectID", Op = "=", Data = projectid });
            if (!model_status.IsNullOrEmpty())
                query.Filters.Add(new Filter { Filed = "ModelStatus", Op = "=", Data = model_status });
            if (!facility_type.IsNullOrEmpty())
                query.Filters.Add(new Filter { Filed = "Facility_Type", Op = "=", Data = facility_type });
            if (datasource_startdate!= DateTime.MinValue)
                query.Filters.Add(new Filter { Filed = "DataSource_StartDate", Op = ">=", Data = datasource_startdate.ToString("yyyy-MM-dd") });
            if (datasource_enddate != DateTime.MinValue)
                query.Filters.Add(new Filter { Filed = "DataSource_EndDate", Op = "<=", Data = datasource_enddate.ToString("yyyy-MM-dd") });
            return query;
        }
    }
}
