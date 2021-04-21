using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using Newtonsoft.Json;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Contracts.Services;
using prboard.api.domain.Connections.Models;
using prboard.api.infrastructure.github.Models;
using RestSharp;

namespace prboard.api.infrastructure.github.Services
{
    [DomainService]
    public class GitHubGetUserService : IGitGetUserService
    {
        private readonly IMapper _mapper;
        public GitAccountType Type { get; } = GitAccountType.GitHub;

        public GitHubGetUserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<GitUser> GetUserAsync(string accessToken)
        {
            var client = new RestClient("https://api.github.com");
            client.AddDefaultHeader("Authorization", "token " + accessToken);
            var request = new RestRequest("user", DataFormat.Json);

            var response = await client.ExecuteGetAsync(request);
            
            var gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(response.Content);

            return _mapper.Map<GitUser>(gitHubUser);
        }
    }
}