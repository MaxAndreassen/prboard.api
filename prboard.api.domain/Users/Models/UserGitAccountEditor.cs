using System;
using prboard.api.data.Users.Enums;

namespace prboard.api.domain.Users.Models
{
    public class UserGitAccountEditor
    {
        public Guid? Uuid { get; set; }
        
        public Guid UserUuid { get; set; }
        
        public GitAccountType AccountType { get; set; }
        
        public string SourceUserIdentity { get; set; }
        
        public string AccessToken { get; set; }
    }
}