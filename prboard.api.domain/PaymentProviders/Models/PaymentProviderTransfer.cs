namespace prboard.api.domain.PaymentProviders.Models
{
    public class PaymentProviderTransfer
    {
        public long Amount { get; set; }
        
        public string CreatedAt { get; set; }
        
        public string DestinationUserStripeId { get; set; }
        
        public string Id { get; set; }
        
        public string EventName { get; set; }
        
        public string PurchaserUsername { get; set; }
        
        public string Type { get; set; }
    }
}