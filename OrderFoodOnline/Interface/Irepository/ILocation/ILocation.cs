using OrderFoodOnline.Dto.Location.Command;
using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Location;

namespace OrderFoodOnline.Interface.Irepository.ILocation
{
    public interface ILocation : IGenericRepository<Location_En>
    {
        Task<string> Get_Location_User();
    }
}
