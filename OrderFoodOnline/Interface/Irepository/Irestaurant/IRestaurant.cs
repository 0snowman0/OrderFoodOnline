using OrderFoodOnline.generic;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Interface.Irepository.Irestaurant
{
    public interface IRestaurant : IGenericRepository<Restaurant_En>
    {
        Task<List<int>> GetAllRestaurantIds();
    }
}
