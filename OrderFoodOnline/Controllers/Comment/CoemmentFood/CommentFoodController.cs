using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Comment.CommentFood.Command;
using OrderFoodOnline.Dto.Comment.CommentFood.Quesreis;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Comment;
using OrderFoodOnline.Model.Product.Food;
using System.Reflection.PortableExecutable;

namespace OrderFoodOnline.Controllers.Comment.CoemmentFood
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentFoodController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IuserService _userservice;
        private readonly ICommentFood _commentFood;
        private readonly Istatus _status;
        public CommentFoodController
            (IMapper mapper,
            IuserService userservice,
            ICommentFood commentFood,
            Istatus status)
        {
            _mapper = mapper;
            _userservice = userservice;
            _commentFood = commentFood;
            _status = status;
        }


        [HttpGet("Get/Comment/Food/{Food_Id}")]
        public async Task<ActionResult<IEnumerable<CommentFood_Dto>>> GetAllByFoodId(int Food_Id)
        {
            int ResId = _userservice.GetUserId();

            if (ResId == 0)
                return Ok(_status.ReturnStatus(("Not found this id"), 500));

            var CommentsEn = await _commentFood.GetCommentForFood(Food_Id);

            if (CommentsEn.Count() == 0)
                return Ok(_status.ReturnStatus($"Not found this Food id:{Food_Id}", 404));

            var CommentsDto = _mapper.Map<List<CommentFood_Dto>>(CommentsEn);

            return Ok(CommentsDto);

        }

        [HttpPost]
        public async Task<ActionResult> CreateCommentFood(CommentFood_Create_Dto commentFood_Create_Dto)
        {
            //validate

            int UserId = _userservice.GetUserId();

            if (UserId == 0)
                return Ok(_status.ReturnStatus(("Not found this id"), 500));


            var newComment = _mapper.Map<CommentFood_En>(commentFood_Create_Dto);



            newComment.UpdatedAt = DateTime.Now;
            newComment.CreatedAt = DateTime.Now;
            newComment.UserId = UserId;
            newComment.FoodId = commentFood_Create_Dto.Food_Id;
            newComment.Content = commentFood_Create_Dto.Content;


            if (commentFood_Create_Dto.IdCommentReplye != 0)
                newComment.IsReplye = true;


            await _commentFood.Add(newComment);


            return Ok(newComment.Id);
        }


        [HttpGet("Get/ReplyeComment/{Comment_Id}")]
        public async Task<ActionResult<IEnumerable<CommentFood_Dto>>> GetCommentsReplye(int Comment_Id)
        {
            var CommentsEn = await _commentFood.GetReplyeComemntByIdComment(Comment_Id);

            if (CommentsEn.Count() == 0)
                return Ok(_status.ReturnStatus($"no avalilble any comment for this id:{Comment_Id}", 404));


            var CommentsDto = _mapper.Map<List<CommentFood_Dto>>(CommentsEn);

            return Ok(CommentsDto);

        }
    }
}
