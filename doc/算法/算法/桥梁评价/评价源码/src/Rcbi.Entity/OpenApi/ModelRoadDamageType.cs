using System;
namespace Rcbi.Entity.OpenApi
{ 
    /// <summary>
    /// 车道基本信息
    /// </summary>
    public class ModelRoadDamageType
    { 
        public int ID { get; set; }  
        public string DefectTypeName { get; set; }  
        public string DefectTypeCode { get; set; }  
        public string ParentDefectType { get; set; }

        public string ParentDefectCode { get; set; }
        
    }
}

