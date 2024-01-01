using OrderFoodOnline.Dto.Common.Total;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderFoodOnline.Dto.Comment.CommentRestaurant.Quesreis
{
    public class CommentRestaurant_Dto : BaseDto_Dto
    { 
        public int RestaurantId { get; set; }
        
        public int UserId { get; set; }

        public string Content { get; set; } = null!;
        
        public string? CreatedAt { get; set; }

        public string? UpdatedAt { get; set; }
        
        public bool IsReplye { get; set; }

        public int? IdCommentReplye { get; set; }
        public bool IsReport { get; set; }
    }
}
