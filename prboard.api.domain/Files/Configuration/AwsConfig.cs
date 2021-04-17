namespace prboard.api.domain.Files.Configuration
{
    public class AwsConfig
    {
        public string FileUrlSuffix => $"https://{BucketName}.s3.amazonaws.com/";
        
        public string Secret { get; set; }
        
        public string Public { get; set; }
        
        public string BucketName { get; set; }
    }
}