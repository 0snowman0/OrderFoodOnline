using OrderFoodOnline.Enum.User;
using OrderFoodOnline.Model.Common.Total;

namespace OrderFoodOnline.Model.User
{
    public class User_En : BaseEn_En
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!; 
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public Role_em role { get; set; }
        public string email { get; set; } = null!;

    }
}
