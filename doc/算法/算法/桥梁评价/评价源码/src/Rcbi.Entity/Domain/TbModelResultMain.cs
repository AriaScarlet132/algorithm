using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
    public class TbModelResultMain : BaseModelEntity
    {
        [Column("ID")]
        public int id { get; set; }
        [Column("TaskNO")]
        public string taskno { get; set; }
        [Column("DataSource_StartDate")]
        public DateTime datasource_startdate { get; set; }
        [Column("DataSource_EndDate")]
        public DateTime datasource_enddate { get; set; }
        [Column("ProjectID")]
        public string projectid { get; set; }
        public string short_name { get; set; }
        [Column("Model_Type")]
        public string model_type { get; set; }
        public string model_name { get; set; }
        [Column("ModelStatus")]
        public string modelstatus { get; set; }
        public string model_status_name
        {
            get
            {
                if (modelstatus == "Preparing")
                    return "未开始";
                if (modelstatus == "Start")
                    return "开始";
                if (modelstatus == "Run")
                    return "运行中";
                if (modelstatus == "Success")
                    return "完成";
                return "";
            }
        }
        [Column("ErrMsg")]
        public string errmsg { get; set; }
        [Column("MsgDate")]
        public DateTime msgdate { get; set; }
        [Column("ConfigID")]
        public int configid { get; set; }
        [Column("Callback_Url")]
        public string callback_url { get; set; }
        [Column("DataInserter")]
        public string dataInserter { get; set; }
        [Column("DataInsertTime")]
        public DateTime dataInserttime { get; set; }
        [Column("Facility_Type")]
        public string facility_type { get; set; }

        public string facility_type_name
        {
            get
            {
                if (facility_type.ToLower() == "tunnel")
                    return "隧道";
                if (facility_type.ToLower() == "road")
                    return "路面";
                if (facility_type.ToLower() == "bridge")
                    return "桥梁";
                return "";
            }
        }
        public DateTime create_time { get; set; }
        public string is_submit { get; set; }
        public int is_delete { get; set; }
    }
}
