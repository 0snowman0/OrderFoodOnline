using OrderFoodOnline.generic;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Interface.Irepository.Irestaurant
{
    public interface IRestaurant : IGenericRepository<Restaurant_En>
    {
        List<Restaurant_En> GetAllWithOutAsync();
        Task<List<int>> GetAllRestaurantIds();
    }
}
