using OrderFoodOnline.Model.Product.Food;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Dto.Location.Quesries;
using OrderFoodOnline.Dto.Product.Food.Queries;

namespace OrderFoodOnline.Dto.User.Restaurant.Command
{
    public class Restaurant_Create_Dto
    {
        public string address { get; set; } = null!;
        public string? City { get; set; }

        //public List<Food_Dto>? food_Ens { get; set; } 
    }
}
