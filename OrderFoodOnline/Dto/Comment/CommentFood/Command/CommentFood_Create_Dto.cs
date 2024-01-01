using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrderFoodOnline.Dto.Comment.CommentFood.Command
{
    public class CommentFood_Create_Dto
    {
        public  int  Food_Id { get; set; }
        public string Content { get; set; } = null!;
        public int? IdCommentReplye { get; set; }
    }
}
