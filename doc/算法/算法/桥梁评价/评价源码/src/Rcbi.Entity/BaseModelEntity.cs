using System;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Rcbi.Core.Attributes;

namespace Rcbi.Entity
{
    /// <summary>
    /// 基础实体类
    /// </summary>
    [Serializable]
    public abstract class BaseModelEntity : BaseEntity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("create_user")]
        [NotUpdate]
        [JsonIgnore]
        [XmlIgnore]
        public virtual string CreateUser { get; set; }
        
        /// <summary>
        /// 创建日期
        /// </summary>
        [Column("create_date")]
        [NotUpdate]
        public virtual DateTime? CreateDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Column("update_user")]
        [NotInsert]
        [JsonIgnore]
        [XmlIgnore]
        public virtual string UpdateUser { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        [Column("update_date")]
        [NotInsert]
        [JsonIgnore]
        [XmlIgnore]
        public virtual DateTime? UpdateDate { get; set; }
    }
}
