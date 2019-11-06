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
        public ActionResult<IEnumerable<User>> Get()
        {
            repository = new UserRepository(_iconfig);
            return repository.GetUsers().AsReadOnly();
        }

        [HttpGet("StatusAPI")]
        public ActionResult<IEnumerable<User>> StatusAPI()
        {
            repository = new UserRepository(_iconfig);
            return new List<User>();
        }
        
        [HttpPost("GetUserByLogin")]
        public ActionResult<IEnumerable<User>> GetUserByLogin([FromBody] UserBase user)
        {
            repository = new UserRepository(_iconfig,user);
            return repository.GetUserByLogin().AsReadOnly();
        }

        [HttpPost("Register")]
        public ActionResult<IEnumerable<User>> Register([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            repository = new UserRepository(_iconfig, user);
            repository.Register();

            return Ok();            
        }

        [HttpPut("Update")]
        public ActionResult<IEnumerable<User>> Update([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            repository = new UserRepository(_iconfig, user);
            repository.Update();

            return Ok();
        }

        [HttpDelete("Delete/{Id:int}")]
        public ActionResult<IEnumerable<User>> Delete([System.Web.Http.FromUri()]int Id)
        {
            repository = new UserRepository(_iconfig, new User() { Id = Id});
            repository.Delete();

            return Ok();
        }
    }
}
