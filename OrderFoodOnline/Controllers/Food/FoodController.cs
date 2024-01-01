using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Product.Food.Command;
using OrderFoodOnline.Dto.Product.Food.Queries;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.IFood;
using OrderFoodOnline.Interface.Irepository.IImage;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.Product.Food;
using OrderFoodOnline.Status;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderFoodOnline.Controllers.FoodControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFood _Food;
        private readonly IValidator<Food_Create_Dto> _validator_Food_Create_Dto;
        private readonly IFileService _fileService;
        private readonly Istatus _status;
        private readonly IValidator<Food_Update_Dto> _validator_Food_Update_Dto;
        private readonly IuserService _userservice;
        private readonly IRestaurant _restaurant;
        public Status.Status Status { get; }

        public FoodController(IMapper mapper,
            IFood food_Gen,
            IValidator<Food_Create_Dto> validator_Food_Create_Dto,
            IFileService fileService,
            Istatus _status,
            IValidator<Food_Update_Dto> validator_Food_Update_Dto,
            IuserService userservice,
            IRestaurant restaurant
            )
        {
            _mapper = mapper;
            _Food = food_Gen;
            _validator_Food_Create_Dto = validator_Food_Create_Dto;
            _fileService = fileService;
            this._status = _status;
            _validator_Food_Update_Dto = validator_Food_Update_Dto;
            _userservice = userservice;
            _restaurant = restaurant; 
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food_Dto>>> GetAll()
        {
            var Food_Ens = await _Food.GetAll();

            if (Food_Ens.Count() == 0)
                return Ok(_status.ReturnStatus("not found FoodData", 404));


            var Food_Dtos = _mapper.Map<IEnumerable<Food_Dto>>(Food_Ens);

            return Ok(Food_Dtos);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Food_Dto>> Get(int id)
        {
            var FoodTarget_En = await _Food.Get(id);

            if( FoodTarget_En == null)
                return Ok(_status.ReturnStatus($"NotFound Food_En with Id:{id}", 404));


            var FoodTarget_Dto = _mapper.Map<Food_Dto>(FoodTarget_En);

            return Ok(FoodTarget_Dto);
        }

  
        [HttpPost("AddFoodByRestaurnt/AddList")]
        public async Task<ActionResult> CreateFoods([FromForm] List<Food_Create_Dto> food_Craete_Dto)
        {
            
            foreach(var food in food_Craete_Dto)
            {

                var Validate = await _validator_Food_Create_Dto.ValidateAsync(food);

                if (!Validate.IsValid)
                    return Ok(_status.ReturnStatus(Validate.Errors.ToString(), 400));
            }



            List<Food_En> newFood_En = _mapper.Map<List<Food_En>>(food_Craete_Dto);

            #region image
            int counter = 0;
            foreach(var newfood in newFood_En)
            {
                var imageResult = _fileService.ReturnImageName(food_Craete_Dto[counter].OriginalPhoto);

                if (imageResult.Item1 == 1)
                    newfood.OriginalPhotoName = imageResult.Item2;
                else
                    return Ok(_status.ReturnStatus("Error in add photo", 500));
                counter++;
            }

            #endregion

            #region Set Id
            foreach (var newfood in newFood_En)
                newfood.restaurant_Id = _userservice.GetUserId();
            #endregion

            await _Food.AddList(newFood_En);
           
            return Ok(_status.ReturnStatus("Add progress is  Success", 200));
        }


        [HttpPost("AddFoodByRestaurnt/AddOne")]
        public async Task<ActionResult> CreateFood([FromForm] Food_Create_Dto food_Craete_Dto)
        {

                var Validate = await _validator_Food_Create_Dto.ValidateAsync(food_Craete_Dto);

                if (!Validate.IsValid)
                    return Ok(_status.ReturnStatus(Validate.Errors.ToString(), 400));
           


            var newFood_En = _mapper.Map<Food_En>(food_Craete_Dto);

            #region image{
                var imageResult = _fileService.ReturnImageName(food_Craete_Dto.OriginalPhoto);

                if (imageResult.Item1 == 1)
                    newFood_En.OriginalPhotoName = imageResult.Item2;
                else
                    return Ok(_status.ReturnStatus("Error in add photo", 500));
            #endregion

            #region restaurant section
                newFood_En.restaurant_Id = _userservice.GetUserId();
                newFood_En.restaurant_name = _userservice.GetMyName();
            #endregion

            await _Food.Add(newFood_En);

            return Ok(_status.ReturnStatus("Add progress is  Success", 200));
        }



        [HttpPut("{id}")]
        public async Task<ActionResult>  Update_Food(int id, [FromForm] Food_Update_Dto food_Update_Dto)
        {
            var Validate = await _validator_Food_Update_Dto.ValidateAsync(food_Update_Dto);

            if (!Validate.IsValid)
                return Ok(_status.ReturnStatus(Validate.Errors.ToString(), 400));


            var Food_U_E = await _Food.Get(id);

            if (Food_U_E == null)
                return Ok(_status.ReturnStatus($"Not Found Food with Id:{id}", 404));

             _mapper.Map(food_Update_Dto , Food_U_E);

            await _Food.Update(Food_U_E);

            return Ok(_status.ReturnStatus("Update progress is  Success", 200));
        }


        [HttpDelete()]
        public async Task<ActionResult> Delete(List<int> Ids)
        {
            var listOfFood = new List<Food_En>();

            var Status = new OrderFoodOnline.Status.Status();
            Status.Massage = "";
            Status.status = 404;

            int counter = 0;

            foreach (var id in Ids)
                listOfFood.Add(await _Food.Get(id));
            foreach (var food in listOfFood)
            {
                if (food == null)
                {
                    Status.Massage += $"NotFound food with id:{Ids[counter]}  /  ";
                }
                counter++;
            }
            if (Status.Massage != "")
                return Ok(Status);

            await _Food.Delete(Ids);

            return Ok(_status.ReturnStatus("delete is success.", 204));
        }
    }
}
