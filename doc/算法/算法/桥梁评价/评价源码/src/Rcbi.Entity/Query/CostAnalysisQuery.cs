using System;

using Rcbi.Core.Extensions;

namespace Rcbi.Entity.Query
{
    public class CostAnalysisQuery : LayuiQuery
    {
        public int id { get; set; }
        public string task_id { get; set; }
        public int year { get; set; }
        public string TaskModel { get; set; }
        public string project_code { get; set; }
        public string ConfigID { get; set; }
        public string table_list1 { get; set; }
        public string table_list2 { get; set; }
        public string table_data1 { get; set; }
        public string table_data2 { get; set; }
        public string sectionUnitID { get; set; }
        public string maintainItemID { get; set; }

        public string active { get; set; }

        public string data_field { get; set; }


        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}
