namespace prboard.api.domain
{
    public class LinkConfig
    {
        public string ApiBaseUrl { get; set; }
        
        public string VerificationBaseUrl { get; set; }
        
        public string PasswordResetBaseUrl { get; set; }
        
        public string PlatformBaseUrl { get; set; }

        public string LoginUrl { get; set; }
    }
}