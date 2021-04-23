using foundation.Entities;

namespace prboard.api.data.Users.Entities
{
    public class UserGitAccountEntity : BaseEntity
    {
        public virtual UserEntity User { get; set; }
        
        public virtual GitAccountSourceEntity GitAccountSource { get; set; }
        
        public string SourceUserIdentifier { get; set; }
        
        public string Token { get; set; }
    }
}