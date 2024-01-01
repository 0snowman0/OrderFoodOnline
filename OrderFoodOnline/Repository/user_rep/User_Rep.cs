using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IUser;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Repository.user_rep
{
    public class User_Rep : GenericRepository<User_En> , Iuser
    {
        private readonly Context_En _context;

        public User_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public Task<User_En> Get_User_By_Email(string email)
        {
            var user = _context.user_Ens.FirstOrDefaultAsync(e => e.email == email);

            return user;
        }
    }
}
