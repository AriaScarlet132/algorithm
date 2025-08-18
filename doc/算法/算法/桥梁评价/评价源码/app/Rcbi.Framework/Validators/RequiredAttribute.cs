using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Framework.Validators
{
    /// <summary>
    /// 空验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredAttribute : ValidationAttribute
    {
        public RequiredAttribute() 
        {
            this.ErrorMessage = "为必须输入";
        }

        public override bool IsValid(object value)
        {
            return value == null || string.IsNullOrWhiteSpace(value.ToString());
        }
    }
}
