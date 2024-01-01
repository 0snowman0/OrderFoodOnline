using OrderFoodOnline.Model.Common.Total;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnline.Model.Comment
{
    public class Score_En : BaseEn_En
    {
        [Required]
        public  int  score { get; set; }
        [Required]
        public  int Restaurant_Id { get; set; }
    }
}
