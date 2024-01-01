using OrderFoodOnline.Dto.User.Restaurant.Quesries;
using OrderFoodOnline.Enum.User.Restaurant;

namespace OrderFoodOnline.Dto.User.Delivery.Command
{
    public class Delivery_Create_Dto
    {
        public string Name { get; set; } = null!;
        public TypeOfVehicles typeofVehicles { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
