using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mental.Health.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mental.Health.Web.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {

        private readonly IUserRegistrationService _userRegistrationService;
        public UserRegistrationController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }
        [HttpPut("SignUp")]
        public async Task<ActionResult> CreateUserAccount([FromBody] SignUpRequest request)
        {
            var result = await _userRegistrationService.CreateUserAccount(request);
            return result == null ? (ActionResult)BadRequest() : Ok(result);
        }
        [HttpPut("Login")]
        public async Task<ActionResult> LoginUser([FromBody] SignInRequest request)
        {
            var result = await _userRegistrationService.LoginUser(request);
            return result == null ? (ActionResult)BadRequest() : Ok(result);
        }

    }
}
