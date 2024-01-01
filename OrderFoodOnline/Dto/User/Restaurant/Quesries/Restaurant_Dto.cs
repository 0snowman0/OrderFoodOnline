using OrderFoodOnline.Dto.Location.Quesries;
using OrderFoodOnline.Dto.Product.Food.Queries;
using OrderFoodOnline.Dto.User.Delivery.Quesries;
using OrderFoodOnline.Model.User;
using OrderFoodOnline.Repository.Tools.Location;

namespace OrderFoodOnline.Dto.User.Restaurant.Quesries
{
    public class Restaurant_Dto
    {
        public string address { get; set; } = null!;
        public int rate { get; set; }
        public string? City { get; set; }
        //add relation
        public  Location_Dto? location_Dto{ get; set; }
        public List<Delivery_Dto>? delivery_Dtos { get; set; }
        public  List<Food_Dto>? food_Dtos { get; set; }
    }
}
