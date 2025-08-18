using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Rcbi.Business.FluentValidator;

namespace Rcbi.Business
{
    /// <summary>
    /// 业务验证扩展
    /// </summary>
    public static class FluentValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> IpAddress<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IpAddressValidator());
        }

        public static IList<string> AsStrings(this IList<ValidationFailure> errors) 
        {
            if (errors == null) return null;

            var list = new List<string>();
            foreach (var err in errors) 
            {
                list.Add(err.ErrorMessage);
            }
            return list;
        }
    }
}
