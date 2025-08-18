using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class ModelType : BaseModelEntity
    {
        public string type_code { get; set; }
        public string model_name { get; set; }
        public string facility_type { get; set; }
        public string comment { get; set; }
        public int delete_flag { get; set; }
        public DateTime create_date { get; set; }
    }
}
