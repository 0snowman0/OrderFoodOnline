using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Repository.Restaurant
{
    public class Restaurant_Rep : GenericRepository<Restaurant_En>, IRestaurant
    {
        private readonly Context_En _context;

        public Restaurant_Rep(Context_En context)
            :base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<int>> GetAllRestaurantIds()
        {

            var ids = await _context.Database.SqlQuery<int>($"SELECT ID FROM restaurant_Ens").ToListAsync();

            return ids;
        }

        public List<Restaurant_En> GetAllWithOutAsync()
        {
            return _context.restaurant_Ens.ToList();
        }
    }
}
