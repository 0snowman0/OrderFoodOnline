using OrderFoodOnline.Model.Common.Total;
using OrderFoodOnline.Model.job.recruitment;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.Product.Food;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.User
{
    public class Restaurant_En : BaseEn_En
    {
        [MaxLength(400)]
        public string address { get; set; } = null!;

        public  int  rate { get; set; }

        [MaxLength(100)]
        public  string?  City { get; set; }


        //rel ... 
        public  ICollection<Food_En> food_Ens { get; set; } = new List<Food_En>();
        public  ICollection<Recruitment_En> recruitment_Ens{ get; set; } = new List<Recruitment_En>();
  
    }
}
