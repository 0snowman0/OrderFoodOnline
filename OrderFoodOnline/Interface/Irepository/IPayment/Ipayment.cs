using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Buy;

namespace OrderFoodOnline.Interface.Irepository.IPayment
{
    public interface Ipayment : IGenericRepository<Payment_En>
    {
        Task<Payment_En> GetPaymeentWithTrackingCode(string TrackingCode);
    }
}
