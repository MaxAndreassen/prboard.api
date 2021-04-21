using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace prboard.api.domain.Users.Models
{
    public class UserEditor
    {
        public Guid Uuid { get; set; }
        
        public string Name { get; set; }

        public bool IsAdmin { get; set; }
        
        [JsonIgnore]
        public IFormFile ProfileImage { get; set; }
        
        public string ProfileUrl { get; set; }
        
        public Guid? ExistingProfileUuid { get; set; }
    }
}