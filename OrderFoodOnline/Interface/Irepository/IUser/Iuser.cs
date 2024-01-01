using OrderFoodOnline.generic;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Interface.Irepository.IUser
{
    public interface Iuser : IGenericRepository<User_En>
    {
        Task<User_En> Get_User_By_Email(string email);
    }
}
