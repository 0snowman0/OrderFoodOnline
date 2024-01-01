using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Comment.CommentFood.Command;
using OrderFoodOnline.Dto.Comment.CommentFood.Quesreis;
using OrderFoodOnline.Dto.Comment.CommentRestaurant.Command;
using OrderFoodOnline.Dto.Comment.CommentRestaurant.Quesreis;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Comment;

namespace OrderFoodOnline.Controllers.Comment.CommentRestaurant
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentRestaurantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IuserService _userservice;
        private readonly ICommentRestaurant _commentRestaurant;
        private readonly Istatus _status;
        public CommentRestaurantController
            (IMapper mapper,
            IuserService userservice,
            ICommentRestaurant commentRestaurant,
            Istatus status)
        {
            _mapper = mapper;
            _userservice = userservice;
            _commentRestaurant = commentRestaurant;
            _status = status;
        }


        [HttpGet("Get/Comment/Restaurant/{Restaurant_Id}")]
        public async Task<ActionResult<IEnumerable<CommentRestaurant_Dto>>> GetAllByRestaurantId(int Restaurant_Id)
        {

            var CommentsEn = await _commentRestaurant.GetByRestaurantId(Restaurant_Id);

            if (CommentsEn.Count() == 0)
                return Ok(_status.ReturnStatus($"Not found this Restaurant id:{Restaurant_Id}", 404));

            var CommentsDto = _mapper.Map<List<CommentRestaurant_Dto>>(CommentsEn);

            return Ok(CommentsDto);

        }

        [HttpPost]
        public async Task<ActionResult> CreateCommentRestaurant(CommentRestaurant_Create_Dto commentRestaurant_Create_Dto)
        {
            //validate

            int UserId = _userservice.GetUserId();

            if (UserId == 0)
                return Ok(_status.ReturnStatus(("Not found this id"), 500));


            var newComment = _mapper.Map<CommentRestaurant_En>(commentRestaurant_Create_Dto);



            newComment.UpdatedAt = DateTime.Now;
            newComment.CreatedAt = DateTime.Now;
            newComment.UserId = UserId;
            newComment.Content = commentRestaurant_Create_Dto.Content;


            if (commentRestaurant_Create_Dto.IdCommentReplye != 0)
                newComment.IsReplye = true;


            await _commentRestaurant.Add(newComment);


            return Ok(newComment.Id);
        }


        [HttpGet("Get/ReplyeComment/{Comment_Id}")]
        public async Task<ActionResult<IEnumerable<CommentFood_Dto>>> GetCommentsReplye(int Comment_Id)
        {
            var CommentsEn = await _commentRestaurant.GetReplyCommentByCommentId(Comment_Id);

            if (CommentsEn.Count() == 0)
                return Ok(_status.ReturnStatus($"no avalilble any comment for this id:{Comment_Id}", 404));


            var CommentsDto = _mapper.Map<List<CommentRestaurant_Dto>>(CommentsEn);

            return Ok(CommentsDto);

        }
    }
}
