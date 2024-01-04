using FluentValidation;
using OrderFoodOnline.Dto.User.user.Command;

namespace OrderFoodOnline.Validate.User
{
    public class User_Create_V : AbstractValidator<User_ForRegister_Dto>
    {
        public User_Create_V()
        {
            RuleFor(x => x.Username).GreaterThan("5").LessThan("100").NotNull();
            
            RuleFor(x => x.Password).LessThan("100").NotNull();
            
            RuleFor(x => x.role).NotNull();
        }
    }
}
