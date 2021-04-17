namespace prboard.api.domain.PaymentProviders.Configuration
{
    public class StripeConfig
    {
        public string ApiKey { get; set; }
        
        public string OnboardingReturnUrl { get; set; }
        
        public string OnboardingRefreshUrl { get; set; }
        
        public string PayoutReturnUrl { get; set; }
        
        public string PayoutRefreshUrl { get; set; }
        
        public string SecretSigningKey { get; set; }
    }
}