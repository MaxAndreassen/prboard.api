namespace prboard.api.domain.PaymentProviders.Models
{
    public class PaymentProviderBalance
    {
        public string Currency { get; set; }
        
        public long Balance { get; set; }
        
        public long PendingBalance { get; set; }
    }
}