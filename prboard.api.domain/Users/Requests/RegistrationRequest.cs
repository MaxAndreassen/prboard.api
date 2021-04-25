namespace prboard.api.domain.Users.Requests
{
    public class RegistrationRequest
    {
        public string Name { get; set; }

        public bool OptedIntoMarketingEmails { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string PasswordConfirm { get; set; }
        
        public bool SkipVerification { get; set; }
    }
}