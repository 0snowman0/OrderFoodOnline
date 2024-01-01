using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Repository.Comment
{
    public class Score_Rep : GenericRepository<Score_En>, IScore
    {
        private readonly Context_En _contxet;

        public Score_Rep(Context_En contxet)
            : base(contxet)
        {
            _contxet = contxet;
        }

        public async Task<List<Restaurant_En>> BestRestaurant()
        {
           var TenTop = await _contxet.restaurant_Ens.OrderBy(p => p.rate).Take(10).ToListAsync();
            return TenTop;
        }

        public async Task<List<Restaurant_En>> BestRestaurantCity(string city)
        {
            var topRes = await _contxet.restaurant_Ens.OrderBy(p => p.rate).Where(p => p.City == city).Take(10).ToListAsync();
            return topRes;
        }

        public async Task CalculateScoreOfRestaurant(int RestaurantId)
        {


        }
    }
}
