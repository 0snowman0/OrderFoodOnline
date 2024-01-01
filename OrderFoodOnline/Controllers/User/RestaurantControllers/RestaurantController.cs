using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderFoodOnline.Dto.T_Relation_T.DeliveryAndRestaurant.Command;
using OrderFoodOnline.Dto.User.Delivery.Quesries;
using OrderFoodOnline.Dto.User.Restaurant.Command;
using OrderFoodOnline.Interface.Irepository.IDelivery;
using OrderFoodOnline.Interface.Irepository.ILocation;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Interface.IT_R_T.DeliveryAndRestaurant;
using OrderFoodOnline.Interface.IT_R_T.LocationAndRestaurant;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Location;
using OrderFoodOnline.Model.T_Relation_T;
using OrderFoodOnline.Model.User;
using Swashbuckle.AspNetCore.Filters;

namespace OrderFoodOnline.Controllers.User.RestaurantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _restaurant;
        private readonly IMapper _mapper;
        private readonly Istatus _status;
        private readonly IDelivery _delivery;
        private readonly IuserService _userservice;
        private readonly IDelivery_Restaurant_Relation _delivery_Restaurant_Relation;
        private readonly ILocation _location;
        private readonly ILocation_Restaurant _location_Restaurant;

        public RestaurantController(IRestaurant restaurant,
            IMapper mapper,
            Istatus status,
            IDelivery delivery,
            IDelivery_Restaurant_Relation delivery_Restaurant_Relation,
            IuserService userservice,
            ILocation location,
            ILocation_Restaurant location_Restaurant)
        {
            _restaurant = restaurant;
            _mapper = mapper;
            _status = status;
            _delivery = delivery;
            _delivery_Restaurant_Relation = delivery_Restaurant_Relation;
            _userservice = userservice;
            _location = location;
            _location_Restaurant = location_Restaurant;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _restaurant.GetAll());
        }


        [HttpGet("get/restaursnt/{resId}")]
        public async Task<ActionResult> Get_Restaurant(int resid)
        {
            var target = await _location_Restaurant.Get_Location_By_ResId(resid);
            return Ok(target);
        }


        [HttpPost("Add/Restaurant")]
        public async Task<ActionResult> Create_Restaurant(Restaurant_Create_Dto restaurant_Create_Dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newLocation = new Location_En();
            var newlocation_Restaurant = new Location_Restaurant_Relation_En();

            string JsonLocation = await _location.Get_Location_User();

            // create a dictionary to store the JSON data
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonLocation);

            // get the latitude value
            string latitude = data["Latitude"];

            // get the longitude value
            string longitude = data["Longitude"];


            if (latitude == null || longitude == null)
                return Ok("error 500");


            newLocation = new Location_En()
            {
                Latitude = double.Parse(latitude),
                Longitude = double.Parse(longitude)
            };


            var newRestaurant = new Restaurant_En()
            {
                address = restaurant_Create_Dto.address,
                rate = 1
            };


            await _restaurant.Add(newRestaurant);

            await _location.Add(newLocation);

            newlocation_Restaurant.location_Id = newLocation.Id;
            newlocation_Restaurant.restaurant_Id = newRestaurant.Id;
            await _location_Restaurant.Add(newlocation_Restaurant);


            return Ok("don.");
        }




        [HttpPost("Add/Delivery")]
        public async Task<ActionResult> Add_Delivery_Restaurant(Delivery_Restaurant_Relation_Create_Dto delivery_Restaurant_Relation_Create_Dtos)
        {

            int Id = _userservice.GetUserId();

            if (Id == 0)
                return Ok(_status.ReturnStatus(("Not found this id"), 500));

            var TargetRestaurant = await _restaurant.Get(Id);

            if (TargetRestaurant == null)
                return Ok(Ok(_status.ReturnStatus($"NotFound Restaurant_En with Id:{Id}", 404)));

            var Delivery = new Delivery_En();
            var Deliveryes = new List<Delivery_En>();

            foreach (var item in delivery_Restaurant_Relation_Create_Dtos.Delivery_Ids)
            {
                Delivery = await _delivery.Get(item);

                if (Delivery == null)
                {
                    return Ok(Ok(_status.ReturnStatus($"NotFound Delivery_En with Id:{Id}", 404)));
                }

                Deliveryes.Add(Delivery);
            }


            await _delivery_Restaurant_Relation.AddDeliveryToREstaurant(Id, Deliveryes);
            await _restaurant.SaveAsync();

            return Ok(_status.ReturnStatus($"Adding delivery is success for restaurant with id:{Id}", 200));
        }


        [HttpGet("get/delivery/forRestaurant")]
        public async Task<ActionResult<Delivery_Dto>> Get_Delivery_ForRestaurant()
        {
            var ResId = _userservice.GetUserId();

            if (ResId == 0)
                return Ok(_status.ReturnStatus($"not found user with id:{ResId}", 404));


            var lisOfDelivery = await _delivery_Restaurant_Relation.GetDeliveryWithRestaurantId(ResId);

            if (lisOfDelivery.Count() == 0)
                return Ok(_status.ReturnStatus($"no register any delivery for this restaurant with Id:{ResId}", 200));

            List<Delivery_En> Delivery_Ens = new List<Delivery_En>();

            foreach (var en in lisOfDelivery)
            {
                Delivery_Ens.Add(await _delivery.Get(en.Id));
            }

             var Delivery_Dtos = _mapper.Map<List<Delivery_Dto>>(Delivery_Ens);

            return Ok(Delivery_Dtos);
        }



    }
}
