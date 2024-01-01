using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.IT_R_T.LocationAndRestaurant;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.T_Relation_T;

namespace OrderFoodOnline.Repository.IT_R_T.LocationAndRestaurant
{
    public class Location_Restaurant_Rep : GenericRepository<Location_Restaurant_Relation_En>, ILocation_Restaurant
    {
        private readonly Context_En _context;

        public Location_Restaurant_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<Location_En> Get_Location_By_ResId(int Id_res)
        {
            var locationId = await _context.location_Restaurant_Relation_Ens.Where(p => p.restaurant_Id == Id_res)
                .Select(p => p.location_Id).FirstOrDefaultAsync();

            var Target = await _context.location_Ens.FirstOrDefaultAsync(p => p.Id == locationId);

            return Target;
        }
    }
}
