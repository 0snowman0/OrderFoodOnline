using OrderFoodOnline.Dto.Common.Total;

namespace OrderFoodOnline.Dto.Common.Product
{
    public class BaseProduct_Dto : BaseDto_Dto
    {

        public string Name { get; set; } = null!;


        public string Price { get; set; } = null!;



        public string? description { get; set; }


        public string? ingredients { get; set; } // separated by -



        public IFormFile? OriginalPhoto { get; set; }
    }
}
