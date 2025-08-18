using System;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    [Table("sys_log")]
    public class SystemLog : BaseModelEntity
    {
        [Key]
        [Column("log_id")]
        public long LogId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("ip_address")]
        public string IpAddress { get; set; }

        [Column("log_type")]
        public string LogType { get; set; }

        [Column("log_content")]
    
        public string LogContent{ get; set; }

        public class SystemLogList : SystemLog
        {
            /// <summary>
            /// 真是姓名
            /// </summary>
            [Column("real_name")]
            public string RealName { get; set; }

            [Column("user_name")]
            public string UserName { get; set; }

            [Column("org_name")]
            public string OrgName { get; set; }

            [Column("log_type_name")]
            public string LogTypeName { get; set; }
        }
    }
}