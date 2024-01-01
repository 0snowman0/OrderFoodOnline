
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderFoodOnline.Model.Common.Total;

namespace OrderFoodOnline.Model.Common.Product.CommonProduct
{
    public class BaseProduct_En : BaseEn_En
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(20)]
        public string Price { get; set; } = null!;


        [MaxLength(300)]
        public string? description { get; set; }


        [MaxLength(300)]
        public string? ingredients { get; set; } // separated by -



        [NotMapped]
        public IFormFile? OriginalPhoto { get; set; }

    }
}
