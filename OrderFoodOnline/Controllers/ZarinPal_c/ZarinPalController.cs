using Dto.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto;
using OrderFoodOnline.Dto.Buy.RestaurantFood.Command;
using OrderFoodOnline.Interface.Irepository.IPayment;
using OrderFoodOnline.Interface.Irepository.IUser;
using OrderFoodOnline.Interface.Itools.HelpFunction;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Buy;
using ZarinPal.Class;

namespace OrderFoodOnline.Controllers.ZarinPal_c
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZarinPalController : ControllerBase
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IuserService _userservice;
        private readonly Iuser _user;
        private readonly Ipayment _payment_rep;
        private readonly IHelpFunction _helpFunction;
        public ZarinPalController
            (Payment payment,
            Authority authority,
            Transactions transactions,
            IuserService userservice,
            Iuser user,
            Ipayment payment_rep,
            IHelpFunction helpFunction)
        {
            var expose = new Expose();

            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _userservice = userservice;
            _user = user;
            _payment_rep = payment_rep;
            _helpFunction = helpFunction;
        }






        [HttpPost, Authorize]
        public async Task<ActionResult> BuyFoods(List<BuyFood_Create_Dto> buyFood_Create_Dtos)
        {
            int userid = _userservice.GetUserId();
            var user = await _user.Get(userid);

            if (user == null)
                return NotFound();


            // Get the amount
            int totalAmount = 0;
            foreach (var buyFood_Create_Dto in buyFood_Create_Dtos)
            {
                totalAmount += buyFood_Create_Dto.Amount;
            }


            //Add newPaymentInDatabase
            var Payment_en = new Payment_En()
            {
                UserId = userid,
                Amount = totalAmount,
                RestaurntId = buyFood_Create_Dtos[0].RestaurantId,
                TrackingCode = _helpFunction.GenerateRandomString(10),
                IsSuccess = false,
                Date = DateTime.Now
            };

            //zarinpal ...
            var request = await _payment.Request(new DtoRequest
            {
                Amount = totalAmount,
                CallbackUrl = "https://localhost:44368/api/ZarinPal/verifyFood",
                Description = "nothing ...",
                Email = user.email,
                Mobile = user.Phone,
                MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "

            }, ZarinPal.Class.Payment.Mode.sandbox);


            await _payment_rep.Add(Payment_en);

            return Ok(Payment_en.TrackingCode);
            //send url 
            return Ok($"https://sandbox.zarinpal.com/pg/StartPay/{request.Authority}");
        }






        [HttpPost("verifyFood")]
        public async Task<ActionResult> FinallyBuy
            (test test)
        {
            var user = await _user.Get(test.UserId);

            if (user == null)
                return NotFound();

            // Get the payment verification response
            var verification = await _payment.Verification(new DtoVerification
            {
                Authority = test.authority,
                MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "
            }, ZarinPal.Class.Payment.Mode.sandbox);



           // if (verification.Status != 200)
           // {
                // The payment is successful



                // Update the payment status in the database
                var paymentTraget = await _payment_rep.GetPaymeentWithTrackingCode(test.TrackingCode);
                if (paymentTraget == null)
                    return NotFound("tracking not founde ...");

                paymentTraget.IsSuccess = true;
                await  _payment_rep.SaveAsync();


                // Send a confirmation email to the user
                // ...

                // Grant access to the purchased items
                // ...
                return Ok("done buy.");
           // }
            return BadRequest();
        }









        #region comment

        //rax controller zarinpal
        //[HttpGet("zarinpalSction")]
        //public async Task<ActionResult> zarinpalSction()
        //{
        //    int amount = 0;


        //    var request = await _payment.Request(new DtoRequest
        //    {
        //        Amount = 0,
        //        CallbackUrl = "بعد از تایید کاربر به مجا برگردد",
        //        Description = "توضیح خود را اینجا وارد کنید",
        //        Email = "user email",
        //        Mobile = "user phone",
        //        MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "

        //    }, ZarinPal.Class.Payment.Mode.sandbox);


        //    //send url 
        //    return Ok($"https://sandbox.zarinpal.com/pg/StartPay/{request.Authority}");

        //}


        //[HttpGet("finnalyBuy")]
        //public async Task<ActionResult> finnalyBuy(string authority, string status)
        //{
        //    var verfication = await _payment.Verification(new DtoVerification
        //    {
        //        Amount = 0,
        //        Authority = authority,
        //        MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "
        //    }, ZarinPal.Class.Payment.Mode.sandbox);


        //    if (status == "200")
        //    {
        //        // do work when user buy somthin and is verfy
        //    }
        //    else
        //    {
        //        //send email to user
        //    }
        //    return Ok();
        //}

        #endregion


    }
}

