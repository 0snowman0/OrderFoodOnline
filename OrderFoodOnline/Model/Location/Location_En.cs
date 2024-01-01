using OrderFoodOnline.Model.Common.Total;
using OrderFoodOnline.Model.Product.Food;
using OrderFoodOnline.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.Location
{
    public class Location_En : BaseEn_En
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }

    }
}
