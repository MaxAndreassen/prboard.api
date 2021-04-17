using System;

namespace prboard.api.domain.Users.Requests
{
    public class PasswordResetRequest
    {
        public Guid AttemptUuid { get; set; }
        
        public string Password { get; set; }
        
        public string PasswordConfirm { get; set; }
    }
}