using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Product.Food.Command;
using OrderFoodOnline.Dto.User.Delivery.Command;
using OrderFoodOnline.Dto.User.Delivery.Quesries;
using OrderFoodOnline.Interface.Irepository.IDelivery;
using OrderFoodOnline.Interface.Irepository.IFood;
using OrderFoodOnline.Interface.Irepository.IImage;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Product.Food;
using OrderFoodOnline.Model.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderFoodOnline.Controllers.User.DeliveryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly Istatus _status;
        private readonly IDelivery _delivery;
        private readonly IMapper _mapper;
        private readonly IuserService _userserice;
        private readonly IValidator<Delivery_Create_Dto> _validator_Delivery_Create_V;
        private readonly IFileService _fileService;
        public DeliveryController(Istatus status,
            IDelivery delivery,
            IMapper mapper,
            IuserService userserice,
            IValidator<Delivery_Create_Dto> validator_Delivery_Create_V,
            IFileService fileService)
        {
            _status = status;
            _delivery = delivery;
            _mapper = mapper;
            _userserice = userserice;
            _validator_Delivery_Create_V = validator_Delivery_Create_V;
            _fileService = fileService;
        }



        // GET: api/<DeliveryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery_Dto>>> Get()
        {
            var AllDeliveryes = await _delivery.GetAll();

            if (!AllDeliveryes.Any())
                return Ok(_status.ReturnStatus("no availble any delivery...", 404));


            var AllDeliveryes_Dtos = _mapper.Map<IEnumerable<Delivery_Dto>>(AllDeliveryes);


            return Ok(AllDeliveryes_Dtos);
        }

        // GET api/<DeliveryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery_Dto>> Get(int id)
        {
            var Deliverye = await _delivery.Get(id);

            if (Deliverye == null)
                return Ok(_status.ReturnStatus($"not found delivery with id:{id}", 404));


            var Deliverye_Dto = _mapper.Map<Delivery_Dto>(Deliverye);

            return Ok(Deliverye_Dto);
        }

        // POST api/<DeliveryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]Delivery_Create_Dto delivery_Create_Dto)
        {
            var Validate = await _validator_Delivery_Create_V.ValidateAsync(delivery_Create_Dto);

            if (!Validate.IsValid)
                return Ok(_status.ReturnStatus(Validate.Errors.ToString(), 400));



            var newDelivery = _mapper.Map<Delivery_En>(delivery_Create_Dto);

            #region image{
            var imageResult = _fileService.ReturnImageName(delivery_Create_Dto.Photo);

            if (imageResult.Item1 == 1)
                newDelivery.ImageName = imageResult.Item2;
            else
                return Ok(_status.ReturnStatus("Error in add photo", 500));
            #endregion


            await _delivery.Add(newDelivery);

            return Ok(_status.ReturnStatus("Add is Success", 200));
        }


        // PUT api/<DeliveryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeliveryController>/5
        [HttpDelete("delete/delivery/lisIds")]
        public async Task<ActionResult> Delete(List<int> Ids)
        {
            var listOfDelivery = new List<Delivery_En>();

            var Status = new OrderFoodOnline.Status.Status();
            Status.Massage = "";
            Status.status = 404;

            int counter = 0;

            foreach (var id in Ids)
                listOfDelivery.Add(await _delivery.Get(id));
            
            foreach (var delivery in listOfDelivery)
            {
                if (delivery == null)
                {
                    Status.Massage += $"NotFound food with id:{Ids[counter]}  /  ";
                }
                counter++;
            }
            if (Status.Massage != "")
                return Ok(Status);

            await _delivery.Delete(Ids);

            return Ok(_status.ReturnStatus("delete is success.", 204));
        }
    }
}
