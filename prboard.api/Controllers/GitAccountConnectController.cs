using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Contracts.Services;
using prboard.api.domain.Users.Models;
using prboard.api.domain.Users.Services.Contracts;
using prboard.api.Security;

namespace prboard.api.Controllers
{
    [Route("api/connect")]
    [ApiController]
    public class GitAccountConnectController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IGetAccessTokenService _getAccessTokenService;
        private readonly IUserGitAccountEditService _userGitAccountEditService;

        public GitAccountConnectController(
            ISecurityService securityService,
            IGetAccessTokenService getAccessTokenService,
            IUserGitAccountEditService userGitAccountEditService
            )
        {
            _securityService = securityService;
            _getAccessTokenService = getAccessTokenService;
            _userGitAccountEditService = userGitAccountEditService;
        }
        
        [HttpGet]
        [Route("github/{code}")]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        public async Task<IActionResult> ConnectGitHubAsync(string code)
        {
            var user = await _securityService.GetCurrentUserAsync();

            var accessToken = await _getAccessTokenService.GetAccessToken(code);

            var model = new UserGitAccountEditor
            {
                UserUuid = user.Uuid,
                AccessToken = accessToken,
                AccountType = GitAccountType.GitHub
            };

            await _userGitAccountEditService.UpdateAsync<UserGitAccountEntity>(model);

            return Ok(true);
        }
    }
}