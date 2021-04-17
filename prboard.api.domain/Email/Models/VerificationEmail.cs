using Newtonsoft.Json;

namespace prboard.api.domain.Email.Models
{
    public class VerificationEmail
    {
        [JsonProperty("verifyLink")]
        public string VerifyLink { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}