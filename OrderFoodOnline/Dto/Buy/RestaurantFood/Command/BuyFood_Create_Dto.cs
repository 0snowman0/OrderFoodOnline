using OrderFoodOnline.Dto.Common.Total;

namespace OrderFoodOnline.Dto.Buy.RestaurantFood.Command
{
    public class BuyFood_Create_Dto : BaseDto_Dto
    {
        public int FoodId { get; set; } 

        public  int  RestaurantId { get; set; }
        public  int Amount { get; set; }
    }
}
