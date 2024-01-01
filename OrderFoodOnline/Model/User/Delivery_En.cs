using OrderFoodOnline.Enum.User.Restaurant;
using OrderFoodOnline.Model.Common.Total;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.User
{
    public class Delivery_En : BaseEn_En
    {
        [Required]
        public string Name { get; set; } = null!;
        public  TypeOfVehicles typeofVehicles  { get; set; }

        [Required]
        public string ImageName { get; set; } = null!;

        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
