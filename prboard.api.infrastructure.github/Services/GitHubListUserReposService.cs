using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using Newtonsoft.Json;
using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Contracts.Services;
using prboard.api.domain.GitSources.Models;
using prboard.api.infrastructure.github.Models;
using RestSharp;

namespace prboard.api.infrastructure.github.Services
{
    [DomainService]
    public class GitHubListUserReposService : IGitListUserReposService
    {
        private readonly IMapper _mapper;
        
        public GitAccountType Type { get; } = GitAccountType.GitHub;

        public GitHubListUserReposService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<List<GitRepo>> GetRepositoriesForUserAsync(string accessToken, string username)
        {
            var client = new RestClient("https://api.github.com");
            client.AddDefaultHeader("Authorization", "token " + accessToken);
            var request = new RestRequest("user/repos", DataFormat.Json);

            var response = await client.ExecuteGetAsync(request);
            
            var gitHubUser = JsonConvert.DeserializeObject<List<GitHubRepo>>(response.Content);

            return _mapper.Map<List<GitRepo>>(gitHubUser);
        }
    }
}