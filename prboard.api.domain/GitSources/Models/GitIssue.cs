namespace prboard.api.domain.GitSources.Models
{
    public class GitIssue
    {
        public string Id { get; set; }
        
        public string RepositoryId { get; set; }
        
        public string PullRequestUrl { get; set; }
        
        public string State { get; set; }
        
        public int? Comments { get; set; }
    }
}