using System.Text.RegularExpressions;
using FluentValidation.Validators;


namespace Rcbi.Business.FluentValidator
{
    /// <summary>
    /// IP地址验证
    /// </summary>
    public class IpAddressValidator : PropertyValidator, IRegularExpressionValidator
    {
        private readonly Regex regex;
        private const string expression = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
        public IpAddressValidator() : 
            base(FluentValidationResource.ipaddress_error) 
        {
            regex = new Regex(expression);
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return true;

            if (!regex.IsMatch((string)context.PropertyValue))
            {
                return false;
            }

            return true;
        }

        public string Expression
        {
            get { return expression; }
        }
    }
}
