using Newtonsoft.Json;

namespace prboard.api.domain.Email.Models
{
    public class TemporaryPasswordEmail
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("loginLink")]
        public string Link { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}