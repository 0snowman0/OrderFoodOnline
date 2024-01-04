using OrderFoodOnline.Dto.Common.Total;
using OrderFoodOnline.Enum.User;

namespace OrderFoodOnline.Dto.User.user.Command
{
    public class User_ForRegister_Dto
    {
        public Role_em role { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public  string  Phone { get; set; } = string.Empty;
        public  string email { get; set; } = string.Empty;
    }
}
