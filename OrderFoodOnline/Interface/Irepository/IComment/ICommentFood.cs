using OrderFoodOnline.generic;
using OrderFoodOnline.Model.Comment;

namespace OrderFoodOnline.Interface.Irepository.IComment
{
    public interface ICommentFood : IGenericRepository<CommentFood_En>
    {
        Task<List<CommentFood_En>> GetReplyeComemntByIdComment(int id_Comment);
        Task<List<CommentFood_En>> GetCommentForFood(int id_Food);
        Task<List<CommentFood_En>> GetReplyeForComment(int id_Comment);
    }
}
