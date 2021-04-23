using Newtonsoft.Json;

namespace prboard.api.infrastructure.github.Models
{
    public class GitHubRepo
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        
        [JsonProperty("node_id")]
        public string NodeId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        
        [JsonProperty("owner")]
        public GitHubUser Owner { get; set; }
        
        [JsonProperty("private")]
        public bool? Private { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("assignees_url")]
        public string AssigneesUrl { get; set; }
        
        [JsonProperty("open_issues_count")]
        public int? OpenIssuesCount { get; set; }
    }
}