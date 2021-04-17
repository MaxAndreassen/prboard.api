using System;

namespace prboard.api.domain.Users.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        
        public string Email { get; set; }
        
        public Guid Uuid { get; set; }
        
        public string Username { get; set; }
    }
}