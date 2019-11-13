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
    public class WheaterController  : ControllerBase
    {
        private readonly ILogger<WheaterController> _logger;
        public WheaterRepository repository;
        IConfiguration _iconfig;
        public WheaterController(ILogger<WheaterController> logger, IConfiguration iconfig)
        {
            _logger = logger;
            _iconfig = iconfig;
            repository = new WheaterRepository(iconfig);
        }

        [HttpGet("Get")]
        public IEnumerable<object> Get()
        {
            var Factory = new FactoryRepository(_iconfig);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.Wheater);

            return Repository.GetAll();
        }

        [HttpGet("GetWheaterByCity")]
        public object GetWheaterByCity([FromBody] Wheater wheater)
        {
            var Factory = new FactoryRepository(_iconfig,wheater);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.Wheater);

            return Repository.GetItemById();
        }
    }
}
