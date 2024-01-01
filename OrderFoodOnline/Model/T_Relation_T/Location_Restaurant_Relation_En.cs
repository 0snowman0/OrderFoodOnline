using OrderFoodOnline.Model.Common.Total;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.T_Relation_T
{
    public class Location_Restaurant_Relation_En : BaseEn_En
    {
        public  int  location_Id { get; set; }
        public  int restaurant_Id { get; set; }

        
        [ForeignKey("{restaurant_Id}")]
        public Restaurant_En? restaurant_En{ get; set; }
        [ForeignKey("{location_Id}")]
        public Location_En? location_En{ get; set; }

    }
}
