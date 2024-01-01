using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderFoodOnline.Dto.Common.Total;

namespace OrderFoodOnline.Dto.Score.Quereis
{
    public class BestScore_Dto : BaseDto_Dto
    {
        public string RestaurantName { get; set; } = null!;
        public  int  rank { get; set; }
    }
}
