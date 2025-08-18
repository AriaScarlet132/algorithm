using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Framework.Validators
{
    /// <summary>
    /// 最大长度验证
    /// </summary>
     [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxLengthAttribute : ValidationAttribute
    {
        public int MaxLength;

        public MaxLengthAttribute(int maxLength) 
        {
            this.MaxLength = maxLength;
            this.ErrorMessage = string.Format("长度不能超过{0}位", maxLength);
        }

        public override bool IsValid(object value)
        {
            return value == null || value.ToString().Length <= this.MaxLength;
        }
    }
}