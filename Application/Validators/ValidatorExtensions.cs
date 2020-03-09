using FluentValidation;

namespace Application.Validators
{
    //static class là class có thể dùng ngay mà k cần new ra đối tượng
    public static class ValidatorExtensions
    {
        //T là 1 generic type, có thể viết là 1 chữ khác, kiểu dl động
        //có thể truyền nhiều kdl khác nhau vô nó
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var option = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                //đây gọi là regular expression, là các ký tự viết tắt thể hiện cho những gì trong WithMessage
                .Matches("[A-Z]").WithMessage("Password must contain at least 1 upercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least 1 lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least a number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain non alphanumeric");
            return option;
        }
    }
}