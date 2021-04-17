using Newtonsoft.Json;

namespace prboard.api.domain.Email.Models
{
    public class Result
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("score")]
        public string Score { get; set; }
    }
}