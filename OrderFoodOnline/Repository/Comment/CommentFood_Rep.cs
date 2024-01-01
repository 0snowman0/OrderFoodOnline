using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Irepository.IFood;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.ConnectionToBank;

namespace OrderFoodOnline.Repository.Comment
{
    public class CommentFood_Rep : GenericRepository<CommentFood_En>, ICommentFood
    {
        private readonly Context_En _context;

        public CommentFood_Rep(Context_En context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<CommentFood_En>> GetCommentForFood(int id_Food)
        {
            var Comments = await _context.commentFood_Ens.Where(p => p.FoodId == id_Food && p.IsReplye == false).ToListAsync();
            return Comments;
        }

        public async Task<List<CommentFood_En>> GetReplyeComemntByIdComment(int id_Comment)
        {
            var Comments = await _context.commentFood_Ens.Where(p => p.IdCommentReplye == id_Comment && p.IsReplye == true).ToListAsync();
            return Comments;
        }

        public async Task<List<CommentFood_En>> GetReplyeForComment(int id_Comment)
        {
            var Comments = await _context.commentFood_Ens.Where(p => p.IdCommentReplye == id_Comment).ToListAsync();
            return Comments;
        }
    }
}
