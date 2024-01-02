using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Interface.Irepository.IComment
{
    public interface IScore : IGenericRepository<Score_En>
    {
        Task<List<Restaurant_En>> BestRestaurant();
        Task<List<Restaurant_En>> BestRestaurantCity(string city);

       float CalculateScoreOfRestaurant(int RestaurantId);
    }
}
