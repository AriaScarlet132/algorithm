using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Framework.Validators
{
    /// <summary>
    /// 最小长度验证
    /// </summary>
     [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MinLengthAttribute : ValidationAttribute
    {
        public int MinLength;

        public MinLengthAttribute(int minLength) 
        {
            MinLength = minLength;
            this.ErrorMessage = string.Format("长度不能小于{0}位", minLength);
        }

        public override bool IsValid(object value)
        {
            return value == null || value.ToString().Length >= this.MinLength;
        }
    }
}