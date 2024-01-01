using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnline.Dto.Score.Command
{
    public class Score_Create_Dto
    {
        public int score { get; set; }

        public int Restaurant_Id { get; set; }
    }
}
