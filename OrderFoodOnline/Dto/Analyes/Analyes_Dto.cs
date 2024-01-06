using OrderFoodOnline.Dto.Common.Total;
using OrderFoodOnline.Model.Analyes;

namespace OrderFoodOnline.Dto.Analyes
{
    public class Analyes_Dto : BaseDto_Dto
    {
        public int RestaurantId { get; set; }
        public int TotalAmount { get; set; }
        public DateTime date { get; set; }

        public List<ProductAnalyes_Dto>? productAnalyes_Ens { get; set; }
         
    }
}
