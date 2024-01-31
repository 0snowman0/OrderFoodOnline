using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderFoodOnline.Controllers.ZarinPal_c;
using OrderFoodOnline.Dto.Location.Command;
using OrderFoodOnline.Interface.Irepository.ILocation;
using OrderFoodOnline.Interface.IT_R_T.LocationAndRestaurant;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
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
        private readonly ILocation_Restaurant _location_Restaurant;
        private readonly Istatus _status;

        public LocationController(IMapper mapper, ILocation location, IuserService userservice, Istatus status)
        {
            _mapper = mapper;
            _location = location;
            _userservice = userservice;
            _status = status;
        }

        public LocationController(ILocation_Restaurant location_Restaurant)
        {
            _location_Restaurant = location_Restaurant;
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

        [HttpPost("RestaurantAroundLocation")]
        public async Task<ActionResult> RestaurantAroundLocation(double lat, double lon)
        {
            var locarionRestaurant = await _location_Restaurant.GetAll();

            if (!locarionRestaurant.Any())
                return NotFound(_status.ReturnStatus("", 404));

            var lisDis = new List<double>();

            foreach (var loc in locarionRestaurant)
                lisDis.Add(_location.Distance(lat, lon, loc.location_En.Latitude, loc.location_En.Longitude));

            lisDis.Sort();
            var nearRestaurant = lisDis.Take(5);

            return Ok(nearRestaurant);
        }
    }
}
