using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using Microsoft.AspNetCore.Mvc;

namespace PDVApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        
        private readonly ILogger<User> _logger;
        private readonly ILoginServices _loginService;

        public LoginController(ILogger<User> logger, ILoginServices loginServices)
        {
            _logger = logger;
            _loginService = loginServices;
        }

        [HttpGet(Name = "LogIn")]
        public string Get([FromQuery] LoginCredentials credentials)
        {
            return _loginService.Authenticate(credentials);

        }

        [HttpPost(Name = "RegisterUser")]
        public Result Post([FromBody] UserFactory userFactory)
        {
            return _loginService.Register(userFactory);

        }


    }
}