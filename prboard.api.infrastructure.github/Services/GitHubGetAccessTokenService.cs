using System.Threading.Tasks;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using prboard.api.domain;
using prboard.api.domain.GitSources.Contracts.Services;
using prboard.api.infrastructure.github.Models;
using RestSharp;

namespace prboard.api.infrastructure.github.Services
{
    [DomainService]
    public class GitHubGetAccessTokenService : IGetAccessTokenService
    {
        private readonly GitHubConfig _githubConfig;
        private readonly LinkConfig _linkConfig;

        public GitHubGetAccessTokenService(
            IOptions<LinkConfig> linkOptions,
            IOptions<GitHubConfig> githubOptions
            )
        {
            _githubConfig = githubOptions.Value;
            _linkConfig = linkOptions.Value;
        }
        
        public async Task<string> GetAccessToken(string code)
        {
            var client = new RestClient("https://github.com");
            client.AddDefaultParameter("code", code);
            client.AddDefaultParameter("redirect_uri", _linkConfig.PlatformBaseUrl + "/connect/github");
            client.AddDefaultParameter("client_id", _githubConfig.ClientId);
            client.AddDefaultParameter("client_secret", _githubConfig.ClientSecret);
            var request = new RestRequest("login/oauth/access_token", DataFormat.Json);

            var response = await client.ExecutePostAsync(request);

            var token = JsonConvert.DeserializeObject<GithubAccessTokenResponse>(response.Content);

            return token.AccessToken;
        }
    }
}