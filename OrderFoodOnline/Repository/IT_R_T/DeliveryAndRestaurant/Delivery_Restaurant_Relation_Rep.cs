using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.Interface.IT_R_T.DeliveryAndRestaurant;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.T_Relation_T;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Repository.IT_R_T.DeliveryAndRestaurant
{
    public class Delivery_Restaurant_Relation_Rep : IDelivery_Restaurant_Relation
    {
        private readonly Context_En _context;

        public Delivery_Restaurant_Relation_Rep(Context_En context)
        {
            _context = context;
        }

        public async Task AddDeliveryToREstaurant(int IdOfRestaurant, List<Delivery_En> delivery_Ens)
        {
            var Restaurant = await _context.restaurant_Ens.FirstOrDefaultAsync(p => p.Id == IdOfRestaurant);

            var NewRequrd = new Delivery_Restaurant_Relation_En();

            var ListNewRequrd = new List<Delivery_Restaurant_Relation_En>();

            foreach (var en in delivery_Ens)
            {
                NewRequrd.Restaurant_Id = IdOfRestaurant;
                NewRequrd.Delivery_Id = en.Id;
                NewRequrd.delivery_Ens = en;
                NewRequrd.restaurant_Ens = Restaurant;

                //check validaiton ... 
                if (NewRequrd.restaurant_Ens == null || NewRequrd.delivery_Ens == null)
                     new ArgumentException();

                ListNewRequrd.Add(NewRequrd);
            }


            await _context.delivery_Restaurant_Relation_Ens.AddRangeAsync(ListNewRequrd);
        }

        public async Task<List<Delivery_Restaurant_Relation_En>> GetDeliveryWithRestaurantId(int id)
        {
            var lisOfTbl = await _context.delivery_Restaurant_Relation_Ens.Where(en => en.Restaurant_Id == id).ToListAsync();
            return lisOfTbl;
        }

        public async Task<List<Delivery_Restaurant_Relation_En>> GetRestaurantWithDeliveryId(int Id)
        {
            var lisOfTbl = await _context.delivery_Restaurant_Relation_Ens.Where(en => en.Delivery_Id == Id).ToListAsync();
            return lisOfTbl;
        }

    }
}
