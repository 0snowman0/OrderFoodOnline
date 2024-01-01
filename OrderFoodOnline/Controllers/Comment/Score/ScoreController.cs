using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Score.Command;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Comment;

namespace OrderFoodOnline.Controllers.Comment.Score
{
    [Route("api/[controller]")]
    [ApiController]

    public class ScoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IuserService _userService;
        private readonly IScore _score;
        private readonly IRestaurant _restaurant;
        private readonly Istatus _status;
        public ScoreController(IMapper mapper,
            IuserService userService, 
            IScore score ,
            IRestaurant restaurant,
            Istatus status)
        {
            _mapper = mapper;
            _userService = userService;
            _score = score;
            _restaurant = restaurant;
            _status = status;
        }

        [HttpPost]
        public async Task<ActionResult> CreateScore([FromForm] Score_Create_Dto score_Create)
        {
            //validate ...

            var newscore = _mapper.Map<Score_En>(score_Create);

            await _score.Add(newscore);
            
            return Ok(newscore.Id);
        }


        [HttpGet]
        public async Task<ActionResult> GetListOfRankRestaurant()
        {
            var idsOfRestaurant = await _restaurant.GetAllRestaurantIds();

            if (idsOfRestaurant.Count() == 0)
                return NotFound(_status.ReturnStatus("not found any restaurant ids", 404));


            foreach (var id in idsOfRestaurant)
            {

            }


            return Ok();

        }

    }
}
