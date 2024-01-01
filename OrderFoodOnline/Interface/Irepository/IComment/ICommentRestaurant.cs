using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Comment;

namespace OrderFoodOnline.Interface.Irepository.IComment
{
    public interface ICommentRestaurant :IGenericRepository<CommentRestaurant_En>
    {
        Task<List<CommentRestaurant_En>> GetByRestaurantId(int restaurantId);
        Task<List<CommentRestaurant_En>> GetReplyCommentByCommentId(int commentId);

    }
}
