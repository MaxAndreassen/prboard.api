using System;

namespace prboard.api.domain.Users.Models
{
    public class UserSummaryAnon
    {
        public Guid Uuid { get; set; }

        public string ProfileUrl { get; set; }
        
        public Guid? ExistingProfileUuid { get; set; }

        public bool IsAdmin { get; set; }
        
        public bool IsEmailVerified { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}