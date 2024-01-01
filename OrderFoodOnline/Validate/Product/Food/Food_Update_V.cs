using FluentValidation;
using OrderFoodOnline.Dto.Product.Food.Command;

namespace OrderFoodOnline.Validate.Product.Food
{
    public class Food_Update_V : AbstractValidator<Food_Update_Dto>
    {
        public Food_Update_V()
        {
            RuleFor(n => n.Name).MaximumLength(100).NotNull();

            RuleFor(p => p.Price).MaximumLength(20).NotNull();

            RuleFor(d => d.description).MaximumLength(300);

            RuleFor(i => i.ingredients).MaximumLength(300);

            RuleFor(s => s.serving_size).MaximumLength(50);

            RuleFor(p => p.preparation_time).GetType();
        }
    }
}
