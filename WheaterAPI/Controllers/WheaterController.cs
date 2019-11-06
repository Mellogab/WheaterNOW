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
    public class WheaterController : ControllerBase
    {
        private readonly ILogger<WheaterController> _logger;
        public WheaterRepository repository;

        public WheaterController(ILogger<WheaterController> logger, IConfiguration iconfig)
        {
            _logger = logger;
            repository = new WheaterRepository(iconfig);
        }

        [HttpGet("Get")]
        public ActionResult<IEnumerable<Wheater>> Get()
        {
            return repository.GetWheaters().AsReadOnly();
        }

        [HttpGet("GetWheaterByCity")]
        public ActionResult<IEnumerable<Wheater>> GetWheaterByCity([FromBody] Wheater wheater)
        {
            return repository.GetWheaterByCity(wheater).AsReadOnly();
        }

        [HttpGet("GetWheaterBetweenTemperatures")]
        public ActionResult<IEnumerable<Wheater>> GetWheaterBetweenTemperatures([FromBody] Wheater wheater)
        {
            return repository.GetWheaterBetweenTemperatures(wheater).AsReadOnly();
        }

        [HttpGet("GetCities")]
        public ActionResult<IEnumerable<string>> GetCities()
        {
            return repository.GetCitiesMonitored().AsReadOnly();
        }
    }
}
