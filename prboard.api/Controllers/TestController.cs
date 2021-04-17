using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prboard.api.domain.Users.Services.Contracts;
using prboard.api.Security;

namespace prboard.api.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public TestController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }
        
        [HttpGet]
        [Route("auth")]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        public async Task<IActionResult> AuthTestAsync()
        {
            return Ok(await _userRegistrationService.TestAsync());
        }
    }
}
