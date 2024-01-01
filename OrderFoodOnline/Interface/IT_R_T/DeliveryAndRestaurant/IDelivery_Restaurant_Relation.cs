using OrderFoodOnline.Model.T_Relation_T;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Interface.IT_R_T.DeliveryAndRestaurant
{
    public interface IDelivery_Restaurant_Relation 
    {
        Task<List<Delivery_Restaurant_Relation_En>> GetRestaurantWithDeliveryId(int Id);
        Task<List<Delivery_Restaurant_Relation_En>> GetDeliveryWithRestaurantId(int id);
        Task AddDeliveryToREstaurant(int IdOfRestaurant, List<Delivery_En> delivery_Ens);
    }
}
