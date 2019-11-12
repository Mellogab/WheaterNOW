using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WheaterAPI.Factory;
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
        public IConfiguration _iconfig;

        public MonitorCityController(ILogger<MonitorCityController> logger, IConfiguration iconfig)
        {
            _logger = logger;
            _iconfig = iconfig;
            repository = new MonitorCityRepository(iconfig);
        }

        [HttpGet("Get")]
        public IEnumerable<object> Get()
        {
            var Factory = new FactoryRepository(_iconfig);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.MonitorCiry);

            return Repository.GetAll();
        }
        
        [HttpPost("GetCitySearched")]
        public object GetCitySearched([FromBody] MonitorCity city)
        {
            var Factory = new FactoryRepository(_iconfig,city);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.MonitorCiry);

            return Repository.GetItemById();
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] MonitorCity city)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var Factory = new FactoryRepository(_iconfig, city);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.MonitorCiry);

            Repository.Add();

            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] MonitorCity city)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var Factory = new FactoryRepository(_iconfig, city);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.MonitorCiry);

            Repository.Update();

            return Ok();
        }

        [HttpDelete("Delete/{Id:int}")]
        public ActionResult Delete([System.Web.Http.FromUri()]int Id)
        {
            var Factory = new FactoryRepository(_iconfig, new MonitorCity { Id = Id });
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.MonitorCiry);

            Repository.Remove();

            return Ok();
        }
    }
}

