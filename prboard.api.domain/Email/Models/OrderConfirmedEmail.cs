using Newtonsoft.Json;

namespace prboard.api.domain.Email.Models
{
    public class OrderConfirmedEmail
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("eventName")]
        public string EventName { get; set; }
        
        [JsonProperty("eventLink")]
        public string EventLink { get; set; }
        
        [JsonProperty("organiserName")]
        public string OrganiserName { get; set; }
        
        [JsonProperty("organiserEmail")]
        public string OrganiserEmail { get; set; }
        
        [JsonProperty("priceText")]
        public string PriceText { get; set; }
        
        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }
}