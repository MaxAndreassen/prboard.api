using Newtonsoft.Json;

namespace prboard.api.domain.Email.Models
{
    public class PasswordResetEmail
    {
        [JsonProperty("forgottenPasswordLink")]
        public string Link { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}