using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IAnalyes;
using OrderFoodOnline.Model.Analyes;
using OrderFoodOnline.Model.ConnectionToBank;
using System.Net.NetworkInformation;

namespace OrderFoodOnline.Repository.Analyes
{
    public class ProductAnalyes_Rep : GenericRepository<ProductAnalyes_En> , IProductAnalyes
    {
        private readonly Context_En _context;

        public ProductAnalyes_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }
    }
}
