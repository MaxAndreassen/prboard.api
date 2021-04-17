using Newtonsoft.Json;

namespace prboard.api.domain.Email.Models
{
    public class PayoutCreatedEmail
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("payoutAmount")]
        public string PayoutAmount { get; set; }
        
        [JsonProperty("payoutLink")]
        public string PayoutLink { get; set; }
        
        [JsonProperty("payoutId")]
        public string PayoutId { get; set; }
    }
}