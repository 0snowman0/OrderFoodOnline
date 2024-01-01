using OrderFoodOnline.Model.User;

namespace OrderFoodOnline.Interface.Itools.IUserService
{
    public interface IAuthenticationTools
    {
        Task<User_En> GetByUsernameAsync(string username);

        void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt);

        bool Verify(string Password, byte[] PasswordHash, byte[] PasswordSalt);

        string CreateToken(User_En user);

        //string GetMyName();
    }
}
