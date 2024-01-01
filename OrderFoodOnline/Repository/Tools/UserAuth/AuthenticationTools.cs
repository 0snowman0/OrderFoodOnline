using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderFoodOnline.Repository.Tools.UserAuth
{
    public class AuthenticationTools : IAuthenticationTools
    {
        private Context_En _context;
        private readonly IConfiguration _configuration;

        public AuthenticationTools(Context_En context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public async Task<User_En> GetByUsernameAsync(string username)
        {
            return await _context.user_Ens.FirstOrDefaultAsync(u => u.Username == username);
        }

        public void CreatePasswordHash
            (string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));

            }
        }


        public bool Verify(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computedHash.SequenceEqual(PasswordHash);
            }
        }




        public string CreateToken(User_En user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role , user.role.ToString()),
        new Claim(ClaimTypes.SerialNumber , user.Id.ToString()),
        new Claim(ClaimTypes.Email , user.email.ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.WriteToken(token);



            return jwt;
        }
    }
}
