using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.User;
using System.Linq;

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

        public  float CalculateScoreOfRestaurant(int RestaurantId)
        {
            var scores = _contxet.score_Ens.Where(p => p.Restaurant_Id == RestaurantId).ToList();


            int sum = 0 ,  count;
            foreach (var score in scores)
            {
                sum += score.score;
            }
            count = scores.Count();
            float ave = (float)sum / count;

            return ave;
        }
    }
}
