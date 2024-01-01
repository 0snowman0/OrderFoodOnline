using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.ConnectionToBank;

namespace OrderFoodOnline.Repository.Comment
{
    public class CommentRestaurant_Rep : GenericRepository<CommentRestaurant_En> , ICommentRestaurant
    {
        private readonly Context_En _context;

        public CommentRestaurant_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<CommentRestaurant_En>> GetByRestaurantId(int restaurantId)
        {
            var comments = await _context.commentRestaurant_Ens.Where(p => p.RestaurantId == restaurantId && p.IsReplye == false).ToListAsync();
            return comments;
        }

        public async Task<List<CommentRestaurant_En>> GetReplyCommentByCommentId(int commentId)
        {
            var comments = await _context.commentRestaurant_Ens.Where(p => p.IdCommentReplye == commentId && p.IsReplye == true).ToListAsync();
            return comments;
        }
    }
}
