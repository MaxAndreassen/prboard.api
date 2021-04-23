namespace prboard.api.domain.GitSources.Models
{
    public class GitRepo
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string OwnerName { get; set; }
        
        public string Description { get; set; }
        
        public int? OpenIssuesCount { get; set; }
        
        public string AvatarUrl { get; set; }
        
        public string Source { get; set; }
    }
}