using OrderFoodOnline.Dto.Common.Product;
using OrderFoodOnline.Enum.Product;
namespace OrderFoodOnline.Dto.Product.Food.Queries
{
    public class Food_Dto : BaseProduct_Dto
    {

        public string? serving_size { get; set; }

        public int preparation_time { get; set; }

        public int rating { get; set; }

        public Food_type_em food_Type_Em { get; set; }

        public string OriginalPhotoName { get; set; } = null!;

        public int restaurant_Id { get; set; }

    }
}
