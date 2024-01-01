using OrderFoodOnline.Dto.Common.Total;
using OrderFoodOnline.Dto.User.Restaurant.Quesries;

namespace OrderFoodOnline.Dto.Location.Quesries
{
    public class Location_Dto : BaseDto_Dto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }

    }
}
