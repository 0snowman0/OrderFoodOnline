using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrderFoodOnline.Dto.Product.Food.Command;
using OrderFoodOnline.Dto.User.user.Quesries;
using OrderFoodOnline.Enum.User;
using OrderFoodOnline.Interface.Irepository.IUser;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.User;
using OrderFoodOnline.Model.User.Token;
using OrderFoodOnline.Repository.Tools.UserAuth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderFoodOnline.Controllers.User.AuthorizationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public static User_En user = new User_En();
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationTools _authenticationTools;
        private readonly Iuser _user;
        private readonly Istatus _status;
        private readonly IValidator<User_ForRegister_Dto> _validator_user_V;
        private readonly IuserService _userservice;
        public AuthorizationController(
            IConfiguration configuration, 
            IAuthenticationTools authenticationTools,
            Iuser user,
            Istatus status,
            IValidator<User_ForRegister_Dto> validator_user_V,
            IuserService userservice
            )
        {
            _configuration = configuration;
            _authenticationTools = authenticationTools;
            _user = user;
            _status = status;
            _validator_user_V = validator_user_V;
            _userservice = userservice;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var user = _userservice.GetMyName();
            return Ok( user );
        }


        [HttpPost("register")]
        public async Task<ActionResult<User_En>> Register(User_Dto request)
        {
            //var Validate = await _validator_user_V.ValidateAsync(request);

            //if (!Validate.IsValid)
            //    return Ok(_status.ReturnStatus(Validate.Errors.ToString(), 400));


            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.role = Role_em.restaurant;
            user.email = request.email;

            await _user.Add(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(User_Dto request)
        {
            // 1. از ریپازیتوری یا سرویس مختص کاربران برای دریافت کاربر با کد ملی مورد نظر استفاده کنید.
            var existingUser = await _user.Get_User_By_Email(request.email);

            // 2. بررسی وجود کاربر
            if (existingUser == null)
                return BadRequest("User not registered.");

            // 3. بررسی صحت رمز عبور
            if (!_authenticationTools.Verify(request.Password, existingUser.PasswordHash, existingUser.PasswordSalt))
                return BadRequest("Password is wrong.");

            // 4. ایجاد توکن
            string token = _authenticationTools.CreateToken(existingUser);

            // 5. ایجاد و ذخیره‌ی توکن نوسانی برای احتمالات بالا
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, existingUser);

            // 6. ارسال توکن به کاربر
            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = _authenticationTools.CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken_En GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken_En
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken_En newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }



        #region Private Methhod
        private async void SetRefreshToken(RefreshToken_En newRefreshToken, User_En user)
        {
            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;

            // ذخیره‌ی تغییرات در دیتابیس
              _user.Save();
        }


        #endregion

    }
}
