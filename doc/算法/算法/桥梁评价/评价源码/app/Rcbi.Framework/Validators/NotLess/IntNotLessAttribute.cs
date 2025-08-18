using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Rcbi.Framework.Validators
{
    /// <summary>
    /// 比较两个int类型值，其中一个不能小于另一个
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IntNotLessAttribute : ValidationAttribute
    {
        private const string _FormatErrorMessage = "{0} 不得小于 {1}";
        public string OtherProperty { get; private set; }
        private string _OtherPropertyName;

        public IntNotLessAttribute(string otherProperty, string otherPropertyName)
            : base(_FormatErrorMessage) 
        {
            if (string.IsNullOrEmpty(otherProperty))
            {
                throw new ArgumentNullException("otherProperty");
            }
            this.OtherProperty = otherProperty;
            this._OtherPropertyName = otherPropertyName;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, _OtherPropertyName);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo otherDeProperty = validationContext.ObjectInstance.GetType().GetProperty(OtherProperty);
                object otherDePropertyValue = otherDeProperty.GetValue(validationContext.ObjectInstance, null);

                int dtThis = Convert.ToInt32(value);
                int dtOther = Convert.ToInt32(otherDePropertyValue);

                if (dtThis < dtOther)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
}
