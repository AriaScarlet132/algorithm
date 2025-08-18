using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelTjResultModelcalculationdata
    {

        public DateTime Date { get; set; }

        public string Line { get; set; }

        public string StructureSection { get; set; }

        public string ManagementUnit { get; set; }

        public string StructureAtt { get; set; }

        public string StructureType { get; set; }

        public string ComponentType { get; set; }

        public string Mileage { get; set; }

        public string Defect { get; set; }

        public string DefectType { get; set; }

        public string DefectSeverity { get; set; }

        public string DefectDescription { get; set; }

        public int RingNumber { get; set; }

        public string Section { get; set; }

        public string TaskNO { get; set; }
    }
}