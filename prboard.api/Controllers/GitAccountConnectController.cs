using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foundation.Entities.Contracts;
using foundation.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Contracts.Factories;
using prboard.api.domain.GitSources.Contracts.Services;
using prboard.api.domain.GitSources.Models;
using prboard.api.domain.Users.Models;
using prboard.api.domain.Users.Requests;
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
        private readonly ILoginService _loginService;
        private readonly IGitGetUserServiceFactory _gitGetUserServiceFactory;
        private readonly IGitListUserReposServiceFactory _gitListUserReposServiceFactory;
        private readonly IGitListIssuesServiceFactory _gitListIssuesServiceFactory;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IWorkUnit _workUnit;

        public GitAccountConnectController(
            ISecurityService securityService,
            IGetAccessTokenService getAccessTokenService,
            IUserGitAccountEditService userGitAccountEditService,
            IUserGitAccountListService userGitAccountListService,
            ILoginService loginService,
            IGitGetUserServiceFactory gitGetUserServiceFactory,
            IGitListUserReposServiceFactory gitListUserReposServiceFactory,
            IGitListIssuesServiceFactory gitListIssuesServiceFactory,
            IUserRegistrationService userRegistrationService,
            IRepository<UserEntity> userRepository,
            IWorkUnit workUnit
        )
        {
            _securityService = securityService;
            _getAccessTokenService = getAccessTokenService;
            _userGitAccountEditService = userGitAccountEditService;
            _userGitAccountListService = userGitAccountListService;
            _loginService = loginService;
            _gitGetUserServiceFactory = gitGetUserServiceFactory;
            _gitListUserReposServiceFactory = gitListUserReposServiceFactory;
            _gitListIssuesServiceFactory = gitListIssuesServiceFactory;
            _userRegistrationService = userRegistrationService;
            _userRepository = userRepository;
            _workUnit = workUnit;
        }
        
        [HttpGet]
        [Route("issues")]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        public async Task<IActionResult> ListIssues()
        {
            var user = await _securityService.GetCurrentUserAsync();

            var userGitAccounts = await _userGitAccountListService
                .ListUserGitAccountsAsync<UserGitAccountEntity>(
                    new UserGitAccountQueryParams
                    {
                        UserUuid = user.Uuid
                    });

            var gitHubAccounts = userGitAccounts
                .Where(p => p.GitAccountSource.Type == GitAccountType.GitHub)
                .ToList();

            var issues = new List<GitIssue>();

            foreach (var account in gitHubAccounts)
            {
                var listIssuesService = _gitListIssuesServiceFactory.Produce(GitAccountType.GitHub);

                var accountIssues = await listIssuesService.GetIssuesForUserAsync(account.Token);

                issues.AddRange(accountIssues);
            }

            // Add bitbucket users

            return Ok(issues);
        }

        [HttpGet]
        [Route("repos")]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        public async Task<IActionResult> ListRepos()
        {
            var user = await _securityService.GetCurrentUserAsync();

            var userGitAccounts = await _userGitAccountListService
                .ListUserGitAccountsAsync<UserGitAccountEntity>(
                    new UserGitAccountQueryParams
                    {
                        UserUuid = user.Uuid
                    });

            var gitHubAccounts = userGitAccounts
                .Where(p => p.GitAccountSource.Type == GitAccountType.GitHub)
                .ToList();

            var userRepos = new List<GitRepo>();

            foreach (var account in gitHubAccounts)
            {
                var getUserService = _gitGetUserServiceFactory.Produce(GitAccountType.GitHub);

                var gitHubUser = await getUserService.GetUserAsync(account.Token);

                var getUserRepoService = _gitListUserReposServiceFactory.Produce(GitAccountType.GitHub);

                var gitHubRepos =
                    await getUserRepoService.GetRepositoriesForUserAsync(account.Token, gitHubUser.Username);

                userRepos.AddRange(gitHubRepos);
            }

            // Add bitbucket users

            return Ok(userRepos);
        }

        [HttpGet]
        [Route("accounts")]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        public async Task<IActionResult> ListAccounts()
        {
            var user = await _securityService.GetCurrentUserAsync();

            var userGitAccounts = await _userGitAccountListService
                .ListUserGitAccountsAsync<UserGitAccountEntity>(
                    new UserGitAccountQueryParams
                    {
                        UserUuid = user.Uuid
                    });

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
        public async Task<IActionResult> ConnectGitHubAsync(string code)
        {
            var accessToken = await _getAccessTokenService.GetAccessToken(code);

            var service = _gitGetUserServiceFactory.Produce(GitAccountType.GitHub);

            var githubUser = await service.GetUserAsync(accessToken);

            var user = await _securityService.GetCurrentUserAsync();

            if (user == null)
            {
                user = await _userRepository.FirstOrDefaultAsync(p => p.Email == githubUser.Email);

                if (user == null)
                {
                    var tempPassword = PasswordGenerator.GeneratePassword(10);

                    user = await _userRegistrationService.RegisterAsync(new RegistrationRequest
                    {
                        Email = githubUser.Email,
                        Name = githubUser.Name,
                        Password = tempPassword,
                        PasswordConfirm = tempPassword,
                        OptedIntoMarketingEmails = false,
                        SkipVerification = true
                    });
                }
            }
            
            var loginResponse = new LoginResponse {Email = user.Email, Username = user.Name, Uuid = user.Uuid};

            var token = await _loginService.GenerateTokenAsync(user.Id);

            loginResponse.Token = token;

            var existingAccount = (await _userGitAccountListService.ListUserGitAccountsAsync<UserGitAccountEntity>(
                new UserGitAccountQueryParams
                {
                    SourceIdentifier = githubUser.Id
                }
            )).FirstOrDefault();

            var model = new UserGitAccountEditor
            {
                Uuid = existingAccount?.Uuid,
                UserUuid = user.Uuid,
                SourceUserIdentity = githubUser.Id,
                AccountType = GitAccountType.GitHub,
                AccessToken = accessToken
            };

            await _userGitAccountEditService.UpdateAsync<UserGitAccountEntity>(model);

            await _workUnit.CommitAsync();

            return Ok(loginResponse);
        }
    }
}