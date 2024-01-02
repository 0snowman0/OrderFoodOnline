using Dto.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ZarinPalController(Payment payment, Authority authority, Transactions transactions)
        {
            var expose = new Expose();

            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }

        [HttpGet]
        public async Task<ActionResult> zarinpalSction()
        {
            int amount = 0;


            var request = await _payment.Request(new DtoRequest
            {
                Amount = 0,
                CallbackUrl = "بعد از تایید کاربر به مجا برگردد",
                Description = "توضیح خود را اینجا وارد کنید",
                Email = "user email",
             Mobile = "user phone",
             MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "

            }, ZarinPal.Class.Payment.Mode.sandbox);


            //send url 
            return Ok($"https://sandbox.zarinpal.com/pg/StartPay/{request.Authority}");

        }

        [HttpGet]
        public async Task<ActionResult> finnalyBuy(string authority , string status)
        {
            var verfication = await _payment.Verification(new DtoVerification
            {
                Amount=0,
                Authority = authority,
                MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "
            }, ZarinPal.Class.Payment.Mode.sandbox);


            if(status == "200")
            {
                // do work when user buy somthin and is verfy
            }
            else
            {
                //send email to user
            }
            return Ok();
        }


    }
}
