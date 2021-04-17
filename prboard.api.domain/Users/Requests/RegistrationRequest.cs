using System;

namespace prboard.api.domain.Users.Requests
{
    public class RegistrationRequest
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid CountryUuid { get; set; }
        
        public Guid? AffiliateUserUuid { get; set; }

        public string CompanyName { get; set; }
        
        public bool IsBusiness { get; set; }
        
        public bool OptedIntoMarketingEmails { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string PasswordConfirm { get; set; }
        
        public bool IsSilent { get; set; }
    }
}