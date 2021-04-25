using System;

namespace prboard.api.domain.Users.Models
{
    public class UserGitAccountQueryParams
    {
        public Guid? UserUuid { get; set; }
        
        public string SourceIdentifier { get; set; }
    }
}