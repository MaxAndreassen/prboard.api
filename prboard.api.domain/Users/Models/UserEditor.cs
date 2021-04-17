using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace prboard.api.domain.Users.Models
{
    public class UserEditor
    {
        public Guid Uuid { get; set; }
        
        public string CompanyName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Username { get; set; }
        
        public string PlaystationUsername { get; set; }
        
        public string XboxUsername { get; set; }
        
        public string SteamUsername { get; set; }
        
        public string TwitchUsername { get; set; }
        
        public string TwitterHandle { get; set; }
        
        public bool IsBusiness { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        public bool IsAdmin { get; set; }
        
        [JsonIgnore]
        public IFormFile ProfileImage { get; set; }
        
        public string ProfileUrl { get; set; }
        
        public Guid? ExistingProfileUuid { get; set; }
    }
}