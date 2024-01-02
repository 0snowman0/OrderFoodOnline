using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderFoodOnline.Controllers.ZarinPal_c;
using OrderFoodOnline.Dto.Location.Command;
using OrderFoodOnline.Interface.Irepository.ILocation;
using OrderFoodOnline.Interface.Itools.IUserService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderFoodOnline.Controllers.LocationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocation _location;
        private readonly IuserService _userservice;

        public LocationController(IMapper mapper, ILocation location, IuserService userservice)
        {
            _mapper = mapper;
            _location = location;
            _userservice = userservice;
        }



        // GET: api/<LocationController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var json = await _location.Get_Location_User();
            return Ok(json);
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocationController>
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }
        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
