using OrderFoodOnline.Model.Common.Total;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.Analyes
{
    public class ProductAnalyes_En : BaseEn_En
    {
        public  int FoodId { get; set; }
        public  int Amount { get; set; }
        public  DateTime DateOfSale { get; set; }
        public  int Restaurant_Id  { get; set; }
        public  int Analyes_En_Id  { get; set; }
        [ForeignKey("{Analyes_En_Id}")]
        public  Analyes_En? analyes { get; set; }
    }
}
