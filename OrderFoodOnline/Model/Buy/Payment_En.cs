using OrderFoodOnline.Model.Common.Total;

namespace OrderFoodOnline.Model.Buy
{
    public class Payment_En : BaseEn_En
    {
        public string TrackingCode { get; set; } = null!;
        public  int UserId { get; set; }
        public  int RestaurntId { get; set; }
        public  int Amount { get; set; }
        public  DateTime Date { get; set; }
        public  bool IsSuccess { get; set; }
    }
}
