using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Analyes;

namespace OrderFoodOnline.Interface.Irepository.IAnalyes
{
    public interface IAnalyes : IGenericRepository<Analyes_En>
    {
        Task<Analyes_En?> GetByRestaurantId(int RestaurantId);
    }
}
