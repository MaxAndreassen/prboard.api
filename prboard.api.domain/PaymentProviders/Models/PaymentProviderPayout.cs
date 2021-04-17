namespace prboard.api.domain.PaymentProviders.Models
{
    public class PaymentProviderPayout
    {
        public long Amount { get; set; }
        
        public string CreatedAt { get; set; }
        
        public string DestinationUserStripeId { get; set; }
        
        public string Id { get; set; }
        
        public string Status { get; set; }
    }
}