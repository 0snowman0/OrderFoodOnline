using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Score.Quereis;
using OrderFoodOnline.Interface.Irepository.IComment;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using Swashbuckle.AspNetCore.Filters;

namespace OrderFoodOnline.Controllers.HomePage
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly Istatus _status;
        private readonly IMapper _mapper;
        private readonly IScore _score;

        public HomePageController(Istatus status, IMapper mapper, IScore score)
        {
            _status = status;
            _mapper = mapper;
            _score = score;
        }

        [HttpGet("best/restaurant/inIran")]
        public async Task<ActionResult<List<BestScore_Dto>>> BestRestaurant()
        {
            var topTen = await _score.BestRestaurant(); 

            if(topTen.Count() == 0)
                return NotFound(_status.ReturnStatus("not found tene restaurant" ,404 ));

            var convertDto = _mapper.Map<List<BestScore_Dto>>(topTen);

            return Ok(convertDto);
        }



        [HttpGet("best/restaurant/inUserCity/{city}")]
        public async Task<ActionResult<List<BestScore_Dto>>> BestRestaurantCity(string city)
        {
            var topTen = await _score.BestRestaurantCity(city);

            if (topTen.Count() == 0)
                return NotFound(_status.ReturnStatus("not found tene restaurant", 404));

            var convertDto = _mapper.Map<List<BestScore_Dto>>(topTen);

            return Ok(convertDto);
        }


    }
}
