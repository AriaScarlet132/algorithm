using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 项目信息
    /// </summary> 
    [Serializable]
    public class ProjectSetUser
    { 
        /// <summary>
        /// id
        /// </summary>
        [Column("id")]
        [NotUpdate]
        [NotInsert]
        public string Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Column("itemCode")]
        [NotUpdate]
        [NotInsert]
        public string ItemCode { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("orgName")]
        [NotUpdate]
        [NotInsert]
        public string OrgName { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        [Column("userName")]
        [NotUpdate]
        [NotInsert]
        public string UserName { get; set; }
        /// <summary>
        /// pid
        /// </summary>
        [Column("pid")]
        [NotUpdate]
        [NotInsert]
        public string Pid { get; set; }


        /// <summary>
        /// 类型
        /// </summary>
        
        [Column("type")]
        [NotUpdate]
        [NotInsert] 
        public string Type { get; set; }

        
        /// <summary>
        /// 是否项目成员 1 是 / 0 不是
        /// </summary>
        [Column("is_member")]
        [NotUpdate]
        [NotInsert]
        public int IsMember { get; set; } 

    }
}
