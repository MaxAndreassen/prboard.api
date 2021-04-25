using Newtonsoft.Json;

namespace prboard.api.infrastructure.github.Models
{
    public class GitHubPullRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("patch_url")]
        public string DiffUrl { get; set; }
    }
}