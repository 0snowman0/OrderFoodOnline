using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IPayment;
using OrderFoodOnline.Model.Buy;
using OrderFoodOnline.Model.ConnectionToBank;

namespace OrderFoodOnline.Repository.payment
{
    public class payment_Rep : GenericRepository<Payment_En>, Ipayment
    {
        private readonly Context_En _context;

        public payment_Rep(Context_En context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Payment_En?> GetPaymeentWithTrackingCode(string TrackingCode)
        {
            try
            {

                var payment = await _context.payment_Ens.FirstOrDefaultAsync(p => p.TrackingCode == TrackingCode);
                if ( payment == null ) 
                {
                    throw new ArgumentException("error in GetPaymeentWithTrackingCode");
                }

                return payment;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
