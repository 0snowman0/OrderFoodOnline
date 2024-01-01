using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.job.Recruitment.Command;
using OrderFoodOnline.Dto.job.Recruitment.Quereies;
using OrderFoodOnline.Dto.Product.Food.Command;
using OrderFoodOnline.Interface.Irepository.IImage;
using OrderFoodOnline.Interface.Irepository.Ijob.IRecruitment;
using OrderFoodOnline.Interface.Irepository.Irestaurant;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using OrderFoodOnline.Model.job.recruitment;

namespace OrderFoodOnline.Controllers.Job
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly IRestaurant _restaurant;
        private readonly IMapper _mapper;
        private readonly Istatus _status;
        private readonly IRecruitment _recruitment;
        private readonly IuserService _userservice;
        private readonly IFileService _fileService;

        public JobController(IRestaurant restaurant,
            IMapper mapper,
            Istatus status,
            IRecruitment recruitment,
            IuserService userservice,
            IFileService fileService)
        {
            _restaurant = restaurant;
            _mapper = mapper;
            _status = status;
            _userservice = userservice;
            _recruitment = recruitment;
            _fileService = fileService;
        }



        [HttpGet("Get/Recruitment/{Id}")]
        public async Task<ActionResult<Recruitment_Dto>> Get_One_Recruitment(int Id)
        {
            var Target = await _recruitment.Get(Id);

            if (Target == null)
                return Ok(_status.ReturnStatus($"not found rec with id:{Id}" , 404));


            var TargetDto = _mapper.Map<Recruitment_Dto>(Target);

            return Ok(TargetDto);

        }


        [HttpPost]
        public async Task<ActionResult> Add_recruitment([FromForm]Recruitment_Create_Dto recruitment_Create_Dto)
        {
            //validate ...
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            int ResId =  _userservice.GetUserId();

            if (ResId == 0)
                return Ok(_status.ReturnStatus($"not found restaurant with id:{ResId} probably you have error in backend", 500));


            var newRecuitment = _mapper.Map<Recruitment_En>(recruitment_Create_Dto);

            #region image
            var imageResult = _fileService.ReturnImageName(recruitment_Create_Dto.File);

            if (imageResult.Item1 == 1)
                newRecuitment.file_Name = imageResult.Item2;
            else
                return Ok(_status.ReturnStatus("Error in add photo", 500));
            #endregion

            await _recruitment.Add(newRecuitment);

            return Ok(_status.ReturnStatus($"add is success new rec id is :{newRecuitment.Id}" , 200));

        }



    }
}
