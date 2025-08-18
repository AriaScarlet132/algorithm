using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Rcbi.Entity.Enums
{
    /// <summary>
    /// 接口返回状态
    /// </summary>
    public enum OpenApiResultStatus
    {
        [Description("系统异常")]
        SYSTEM_ERROR = -1,

        [Description("操作成功")]
        SUCCESS = 0,

        [Description("未经授权")]
        UNAUTHORIZED = 1,

        [Description("错误的请求")]
        BAD_REQUEST = 2,

        [Description("被禁止的")]
        FORBIDDEN = 3,

        [Description("接口未找到")]
        NOT_FOUND = 4,

        [Description("参数验证错误")]
        PARAMETER_CHECK_ERROR = 5,

        [Description("权限验证错误")]
        AUTHORITY_CHECK_ERROR = 6,

        [Description("模型状态异常")]
        MODEL_STATUS_ERROR = 7,

        [Description("数据重复提交")]
        REPEAT_SUBMISSION = 8,

        [Description("操作失败")]
        FAIL = 10
    }
}
