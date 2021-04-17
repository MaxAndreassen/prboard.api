namespace prboard.api.domain.Users.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}