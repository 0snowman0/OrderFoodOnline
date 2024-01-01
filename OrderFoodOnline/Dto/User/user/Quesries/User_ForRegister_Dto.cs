using OrderFoodOnline.Dto.Common.Total;
using OrderFoodOnline.Enum.User;

namespace OrderFoodOnline.Dto.User.user.Quesries
{
    public class User_ForRegister_Dto 
    {
        public Role_em role { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
