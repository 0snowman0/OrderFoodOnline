using OrderFoodOnline.Dto.Common.Total;
using OrderFoodOnline.Dto.User.Restaurant.Quesries;
using OrderFoodOnline.Enum.User.Restaurant;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnline.Dto.User.Delivery.Quesries
{
    public class Delivery_Dto : BaseDto_Dto
    {
        public string Name { get; set; } = null!;
        public TypeOfVehicles typeofVehicles { get; set; }
        public string ImageName { get; set; } = null!;

        public  List<Restaurant_Dto>? restaurant_Dtos { get; set; }
    }
}
