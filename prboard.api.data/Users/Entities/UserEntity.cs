using System;
using System.Collections.Generic;
using foundation.Entities;
using prboard.api.data.Countries.Entities;
using prboard.api.data.Files.Entities;

namespace prboard.api.data.Users.Entities
{
    public class UserEntity : BaseEntity
    {
        private const int BCryptWorkFactor = 8;

        public string Email { get; set; }
        
        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public bool IsEmailVerified { get; set; }
        
        public string StripeCustomerId { get; set; }

        public virtual FileEntity ProfileImage { get; set; }
        
        public virtual CountryEntity Country { get; set; }
        
        public virtual UserTypeEntity UserType { get; set; }
        
        public virtual IList<UserGitAccountEntity> GitAccounts { get; set; } = new List<UserGitAccountEntity>();

        public bool OptedIntoMarketingEmails { get; set; }
        
        public DateTime? LastActive { get; set; }

        public void ChangePassword(string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentNullException(nameof(newPassword), "A password cannot be null or empty.");

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword, BCrypt.Net.BCrypt.GenerateSalt(BCryptWorkFactor));
        }

        public bool PasswordIsCorrect(string password)
        {
            return !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(PasswordHash) && BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}