using Rcbi.Entity.Domain;
using System;
using System.Collections.Generic;

namespace Rcbi.Entity.Domain
{
    public class CostAnalysisModel
    {
        public string task_id { get; set; }
        public IList<GeneralContent> PriceYear { get; set; }
        public IList<GeneralContent> TaskModel { get; set; }
        public IList<GeneralContent> MdelFINConIndiscount_name { get; set; }
        public IList<GeneralContent> ModelFINConFeeDiscount_name { get; set; }
        public ModelFINConMain ModelFINConMain { get; set; }

        public List<ModelFINConProjectUnitCount> ModelFINConProjectUnitCount_List { get; set; }

        public List<ModelFINConProjectCount> ModelFINConProjectCount_List { get; set; }

        public List<MdelFINConIndiscount> MdelFINConIndiscount_List { get; set; }

        public List<ModelFINConFeeDiscount> ModelFINConFeeDiscount_List { get; set; }

        public TbModelResultMain tbModelResultMain { get; set; }
    }
}