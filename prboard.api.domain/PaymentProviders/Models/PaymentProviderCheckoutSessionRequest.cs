using Newtonsoft.Json;

namespace prboard.api.domain.PaymentProviders.Models
{
    public class PaymentProviderCheckoutSessionRequest
    {
        [JsonProperty("priceId")]
        public string PriceId { get; set; }
    }
}