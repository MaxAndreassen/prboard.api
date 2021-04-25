using Newtonsoft.Json;

namespace prboard.api.infrastructure.github.Models
{
    public class GitHubAccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        
        [JsonProperty("scope")]
        public string Scope { get; set; }
        
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}