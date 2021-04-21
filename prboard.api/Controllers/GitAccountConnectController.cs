using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foundation.Entities.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Contracts.Factories;
using prboard.api.domain.Connections.Contracts.Services;
using prboard.api.domain.Connections.Models;
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
        private readonly IUserGitAccountListService _userGitAccountListService;
        private readonly IGitGetUserServiceFactory _gitGetUserServiceFactory;
        private readonly IWorkUnit _workUnit;

        public GitAccountConnectController(
            ISecurityService securityService,
            IGetAccessTokenService getAccessTokenService,
            IUserGitAccountEditService userGitAccountEditService,
            IUserGitAccountListService userGitAccountListService,
            IGitGetUserServiceFactory gitGetUserServiceFactory,
            IWorkUnit workUnit
            )
        {
            _securityService = securityService;
            _getAccessTokenService = getAccessTokenService;
            _userGitAccountEditService = userGitAccountEditService;
            _userGitAccountListService = userGitAccountListService;
            _gitGetUserServiceFactory = gitGetUserServiceFactory;
            _workUnit = workUnit;
        }

        [HttpGet]
        [Route("accounts")]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        public async Task<IActionResult> ListAccounts()
        {
            var user = await _securityService.GetCurrentUserAsync();

            var userGitAccounts = await _userGitAccountListService
                .ListUserGitAccountsAsync<UserGitAccountEntity>(user.Uuid);

            var gitHubAccounts = userGitAccounts
                .Where(p => p.GitAccountSource.Type == GitAccountType.GitHub)
                .ToList();

            var userAccounts = new List<GitUser>();

            foreach (var account in gitHubAccounts)
            {
                var getUserService = _gitGetUserServiceFactory.Produce(GitAccountType.GitHub);

                var gitHubUser = await getUserService.GetUserAsync(account.Token);
                
                userAccounts.Add(gitHubUser);
            }
            
            // Add bitbucket users

            return Ok(userAccounts);
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

            await _workUnit.CommitAsync();

            return Ok(true);
        }
    }
}