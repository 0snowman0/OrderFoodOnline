using OrderFoodOnline.Enum.Product;
using OrderFoodOnline.Model.Common.Product.CommonProduct;

using OrderFoodOnline.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.Product.Food
{
    public class Food_En : BaseProduct_En
    {

        [MaxLength(50)]
        public string? serving_size { get; set; }

        public int preparation_time { get; set; }

        [MaxLength(75)]
        public string restaurant_name { get; set; } = null!;

        public int rating { get; set; }

        public  string? OriginalPhotoName { get; set; }
        public Food_type_em food_Type_Em { get; set; }

        //add rel
        public  int restaurant_Id { get; set; }

        [ForeignKey("{restaurant_Id}")]
        public  Restaurant_En? restaurant_En{ get; set; }

    }
}
