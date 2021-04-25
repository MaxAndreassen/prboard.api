namespace prboard.api.domain.GitSources.Models
{
    public class GitUser
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Company { get; set; }
        
        public int? PublicRepoCount { get; set; }
        
        public int? PrivateRepoCount { get; set; }
        
        public string AvatarUrl { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
        
        public string Source { get; set; }
    }
}