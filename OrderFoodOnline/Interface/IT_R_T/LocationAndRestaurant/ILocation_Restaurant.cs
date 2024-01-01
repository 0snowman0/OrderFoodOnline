using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.T_Relation_T;

namespace OrderFoodOnline.Interface.IT_R_T.LocationAndRestaurant
{
    public interface ILocation_Restaurant : IGenericRepository<Location_Restaurant_Relation_En>
    {
        Task<Location_En> Get_Location_By_ResId(int Id_res);
    }
}
