using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WheaterAPI.Model;
using WheaterAPI.Repository;
using WheaterAPI.Factory;

namespace WheaterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserRepository repository;
        public IConfiguration _iconfig;
        public UserController(ILogger<UserController> logger, IConfiguration iconfig)
        {
            _logger = logger;
            _iconfig = iconfig;
        }

        [HttpGet("Get")]
        public IEnumerable<object> Get()
        {
            var Factory = new FactoryRepository(_iconfig);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.User);

            return Repository.GetAll();
        }

        [HttpGet("StatusAPI")]
        public IEnumerable<object> StatusAPI()
        {
            return new List<User>();
        }

        [HttpPost("GetUserByLogin")]
        public object GetUserByLogin([FromBody] UserBase user)
        {
            var Factory = new FactoryRepository(_iconfig,user);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.User);

            return Repository.GetItemById();
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var Factory = new FactoryRepository(_iconfig,user);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.User);

            Repository.Add();

            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var Factory = new FactoryRepository(_iconfig,user);
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.User);

            Repository.Update();

            return Ok();
        }

        [HttpDelete("Delete/{Id:int}")]
        public ActionResult Delete([System.Web.Http.FromUri()]int Id)
        {
            var Factory = new FactoryRepository(_iconfig, new User { Id = Id });
            IRepository Repository = Factory.CreateFactoryRepository((int)Enums.Repository.User);

            Repository.Remove();

            return Ok();
        }
    }
}
