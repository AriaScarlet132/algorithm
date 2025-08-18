using FluentValidation;
using FluentValidation.Results;

using Rcbi.Entity.Domain;

namespace Rcbi.Business.Validators
{
    /// <summary>
    /// 用户实体验证
    /// </summary>
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(user => user.UserName).NotEmpty().Length(2, 20);//用户名不能为空并且长度限制
            RuleFor(user => user.Password).NotEmpty().Length(6, 50);//密码不能为空并且长度限制
            ///RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.TrueName).NotEmpty().Length(2, 10);//真实姓名不能为空并且长度限制
        }

        public override ValidationResult Validate(ValidationContext<User> context)
        {
            return base.Validate(context);
        }
    }
}
