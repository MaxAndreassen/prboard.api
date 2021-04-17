namespace prboard.api.domain.PaymentProviders.Models
{
    public class PaymentProviderPaymentIntent
    {
        public string Id { get; set; }

        public string Status { get; set; }
        
        public string ClientSecret { get; set; }
    }
}