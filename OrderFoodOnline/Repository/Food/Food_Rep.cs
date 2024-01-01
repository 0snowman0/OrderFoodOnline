using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IFood;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.Product.Food;

namespace OrderFoodOnline.Repository.Food
{
    public class Food_Rep : GenericRepository<Food_En> , IFood
    {
        private readonly Context_En _context;

        public Food_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }
    }
}
