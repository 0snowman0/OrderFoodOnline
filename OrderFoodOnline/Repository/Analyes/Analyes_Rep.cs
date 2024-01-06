using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IAnalyes;
using OrderFoodOnline.Model.Analyes;
using OrderFoodOnline.Model.ConnectionToBank;

namespace OrderFoodOnline.Repository.Analyes
{
    public class Analyes_Rep : GenericRepository<Analyes_En>, IAnalyes
    {
        private readonly Context_En _context;

        public Analyes_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<Analyes_En?> GetByRestaurantId(int RestaurantId)
        {
            var Target = await _context.analyes_Ens.FirstOrDefaultAsync(p => p.RestaurantId == RestaurantId);
            return Target;
        }
    }
}
