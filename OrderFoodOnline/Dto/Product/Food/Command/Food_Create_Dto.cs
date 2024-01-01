using Microsoft.AspNetCore.Http.HttpResults;
using OrderFoodOnline.Dto.Common.Total;
using OrderFoodOnline.Enum.Product;

namespace OrderFoodOnline.Dto.Product.Food.Command
{
    public class Food_Create_Dto
    {
        public string Name { get; set; } = null!;


        public string Price { get; set; } = null!;


        public string? description { get; set; }



        public string? ingredients { get; set; } // separated by -



        public IFormFile? OriginalPhoto { get; set; }



        public string? serving_size { get; set; }



        public int preparation_time { get; set; }



        public Food_type_em food_Type_Em { get; set; }
    }
}
