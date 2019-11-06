using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WheaterAPI.Model;
using WheaterAPI.Repository;

namespace WheaterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorCityController : ControllerBase
    {
        private readonly ILogger<MonitorCityController> _logger;
        public MonitorCityRepository repository;

        public MonitorCityController(ILogger<MonitorCityController> logger, IConfiguration iconfig)
        {
            _logger = logger;
            repository = new MonitorCityRepository(iconfig);
        }

        [HttpGet("Get")]
        public ActionResult<IEnumerable<MonitorCity>> Get()
        {
            return repository.GetCities().AsReadOnly();
        }
        
        [HttpPost("GetUserByLogin")]
        public ActionResult<IEnumerable<MonitorCity>> GetUserByLogin([FromBody] MonitorCity city)
        {
            return repository.GetCityByName(city).AsReadOnly();
        }

        [HttpPost("Register")]
        public ActionResult<IEnumerable<MonitorCity>> Register([FromBody] MonitorCity city)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            repository.Register(city);

            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult<IEnumerable<MonitorCity>> Update([FromBody] MonitorCity city)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            repository.Update(city);

            return Ok();
        }

        [HttpDelete("Delete/{Id:int}")]
        public ActionResult<IEnumerable<MonitorCity>> Delete([System.Web.Http.FromUri()]int Id)
        {
            repository.Delete(Id);

            return Ok();
        }
    }
}

