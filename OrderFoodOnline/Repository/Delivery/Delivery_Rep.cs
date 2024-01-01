using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IDelivery;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Repository.Delivery
{
    public class Delivery_Rep : GenericRepository<Delivery_En> , IDelivery
    {
        private readonly Context_En _context;

        public Delivery_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }
    }
}
