using FluentValidation;
using OrderFoodOnline.Dto.User.Delivery.Command;
using OrderFoodOnline.Dto.User.user.Quesries;
using OrderFoodOnline.Enum.User.Restaurant;

namespace OrderFoodOnline.Validate.User
{
    public class Delivery_Create_V : AbstractValidator<Delivery_Create_Dto>
    {
        public Delivery_Create_V()
        {
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.typeofVehicles).NotNull();
        }
    }
}

