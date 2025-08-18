using System;

using System.ComponentModel;

namespace Rcbi.Entity.Enums
{
    /// <summary>
    /// 公共状态枚举
    /// </summary>
    public enum State
    {
        /// <summary>
        /// 启用
        /// </summary>
        Enable = 0,

        /// <summary>
        /// 禁用
        /// </summary>
        Disable = 1
    }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuSystemCode
    {
        /// <summary>
        /// 后台
        /// </summary>
        [Description("通用")]
        Admin,

        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        PC_WEB
    }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 普通菜单
        /// </summary>
        [Description("普通菜单")]
        Normal = 1,

        /// <summary>
        /// 控制台
        /// </summary>
        [Description("控制台")]
        Console = 4
    }

    public enum Op 
    {
        /// <summary>
        /// and 
        /// </summary>
        And,
        /// <summary>
        /// or
        /// </summary>
        Or
    }

    /// <summary>
    /// 是或者否
    /// </summary>
    public enum YesOrNo
    {

        /// <summary>
        /// 全部
        /// </summary>
        All = 0,

        /// <summary>
        /// 是
        /// </summary>
        Yes = 1,

        /// <summary>
        /// 否
        /// </summary>
        No = 2
    }

    public enum UserState
    {
        /// <summary>
        /// 未审核
        /// </summary>
        UnChecked = 0,

        /// <summary>
        /// 已审核，可用
        /// </summary>
        Enable = 1,

        /// <summary>
        /// 作废
        /// </summary>
        Disable = 2
    }

    public enum ContentType
    {
        /// <summary>
        /// Json
        /// </summary>
        Json,
        /// <summary>
        /// Xml
        /// </summary>
        Xml
    }

    /// <summary>
    /// 角色类型
    /// </summary>
    public class RoleTypes
    {
        /// <summary>
        /// 普通角色
        /// </summary>
        public const int Normal = 1;

        /// <summary>
        /// 项目角色
        /// </summary>
        public const int Project = 2;
    }
}
