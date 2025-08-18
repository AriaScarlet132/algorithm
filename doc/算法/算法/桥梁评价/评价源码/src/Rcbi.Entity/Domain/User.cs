using System;

using Newtonsoft.Json;

using Rcbi.Core.Attributes;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("sys_user")]
    [Serializable]
    public class User : BaseModelEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        [Column("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Column("real_name")]
        public string TrueName { get; set; }

        /// <summary>
        /// 真实姓名的首字母
        /// </summary>
        [Column("initials")]
        public string Initials { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [Column("work_num")]
        public string WorkNum { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Column("id_num")]
        public string IdNum { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        [Column("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Column("telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        [JsonIgnore]
        [NotUpdate]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        [Column("org_id")]
        public int OrgId { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Column("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Column("dept_id")]
        public int DeptId { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [Column("job_title")]
        public string JobType { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [Column("position")]
        public string Position { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [Column("education")]
        public string Education { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [Column("specialty")]
        public string Specialty { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_num")]
        public int? Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("comments")]
        public string Comment { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        [NotInsert]
        [NotUpdate]
        [Column("is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [Column("wechat_open_id")]
        [NotInsert]
        [NotUpdate]
        [NotQuery]
        public string WxOpenId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("org_name")]
        public string OrgName { get; set; }

        /// <summary>
        /// 公司简称
        /// </summary>
        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("org_name_short")]
        public string OrgNameShort { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [NotInsert]
        [NotUpdate]
        [NotQuery]
        [Column("dept_name")]
        public string DeptName { get; set; }

    }
    
}
