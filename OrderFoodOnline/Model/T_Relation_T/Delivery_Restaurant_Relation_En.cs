using OrderFoodOnline.Model.Common.Total;
using OrderFoodOnline.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.T_Relation_T
{
    public class Delivery_Restaurant_Relation_En : BaseEn_En
    {
        public int Restaurant_Id { get; set; }

        public int Delivery_Id { get; set; }


        [ForeignKey("{Restaurant_Id}")]
        public Restaurant_En? restaurant_Ens { get; set; }



        [ForeignKey("{Delivery_Id}")]
        public Delivery_En? delivery_Ens { get; set; }

    }
}
