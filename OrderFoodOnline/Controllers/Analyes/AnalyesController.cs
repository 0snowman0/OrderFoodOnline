using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnline.Dto.Analyes;
using OrderFoodOnline.Interface.Irepository.IAnalyes;
using OrderFoodOnline.Interface.Itools.ImanageProgram.Istatus;
using OrderFoodOnline.Interface.Itools.IUserService;
using System.Net.NetworkInformation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderFoodOnline.Controllers.Analyes
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAnalyes _analyes;
        private readonly Istatus _status;
        private readonly IuserService _userService;

        public AnalyesController
            (IMapper mapper, 
            IAnalyes analyes, 
            Istatus status, 
            IuserService userService)
        {
            _mapper = mapper;
            _analyes = analyes;
            _status = status;
            _userService = userService;
        }



        // GET: api/<AnalyesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductAnalyes_Dto>>>  Get()
        {
            var AllAnalyes = await _analyes.GetAll();
            
            if(AllAnalyes.Count() == 0 )
                return NotFound(_status.ReturnStatus("not found any analyes date" ,404 ));

            var AllAnalyes_Dto = _mapper.Map<IEnumerable<ProductAnalyes_Dto>>(AllAnalyes);

            return Ok(AllAnalyes_Dto);
        }

        // GET api/<AnalyesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductAnalyes_Dto>> Get(int id)
        {
            var AnalyesEn  = await _analyes.Get(id);

            if (AnalyesEn == null)
                return NotFound(_status.ReturnStatus("not found this analyes date", 404));

            var AnalyesDto = _mapper.Map<ProductAnalyes_Dto>(AnalyesEn);

            return Ok(AnalyesDto);
        }

        // POST api/<AnalyesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnalyesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnalyesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
