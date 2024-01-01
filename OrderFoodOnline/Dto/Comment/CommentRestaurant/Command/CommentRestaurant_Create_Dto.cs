namespace OrderFoodOnline.Dto.Comment.CommentRestaurant.Command
{
    public class CommentRestaurant_Create_Dto
    {
        public int RestaurantId { get; set; }
        public string Content { get; set; } = null!;

        public int? IdCommentReplye { get; set; }

    }
}
