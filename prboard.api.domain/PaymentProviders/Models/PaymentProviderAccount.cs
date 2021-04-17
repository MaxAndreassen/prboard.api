namespace prboard.api.domain.PaymentProviders.Models
{
    public class PaymentProviderAccount
    {
        public string Id { get; set; }
        
        public bool ChargesEnabled { get; set; }
        
        public bool PayoutsEnabled { get; set; }
        
        public bool DetailsSubmitted { get; set; }
    }
}