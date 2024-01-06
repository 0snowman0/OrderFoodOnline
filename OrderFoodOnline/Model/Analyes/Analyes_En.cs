using OrderFoodOnline.Model.Common.Total;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnline.Model.Analyes
{
    public class Analyes_En : BaseEn_En
    {
        
        public  int RestaurantId { get; set; }
        public  int TotalAmount { get; set; }
        public  DateTime date { get; set; }

        public  ICollection<ProductAnalyes_En>? productAnalyes_Ens { get; set; }
         = new List<ProductAnalyes_En>();

    }
}
