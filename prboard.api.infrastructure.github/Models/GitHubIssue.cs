using Newtonsoft.Json;

namespace prboard.api.infrastructure.github.Models
{
    public class GitHubIssue
    {
        [JsonProperty("node_id")]
        public string NodeId { get; set; }
        
        [JsonProperty("repository")]
        public GitHubRepo Repository { get; set; }
        
        [JsonProperty("comments")]
        public int? Comments { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("pull_request")]
        public GitHubPullRequest PullRequest { get; set; }
    }
}