using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using prboard.api.domain.Exceptions;
using prboard.api.domain.Files.Configuration;
using prboard.api.domain.Files.Contracts.Services;

namespace prboard.api.infrastructure.s3.Services
{
    public class PreSignedUrlGenerator : IPreSignedUrlGenerator
    {
        private readonly IAmazonS3 _s3;

        public PreSignedUrlGenerator(IOptions<AwsConfig> awsOptions, string bucketName)
        {
            _s3 = new AmazonS3Client(awsOptions.Value.Public,
                awsOptions.Value.Secret,
                RegionEndpoint.EUWest1
            );

            BucketName = bucketName;
        }
        
        private string BucketName { get; set; }

        public string GetPreSignedUrl(string path)
        {
            if (path == null)
                return string.Empty;

            return GetPreSignedUrl(path, TimeSpan.FromHours(1));
        }

        public string GetPreSignedUrl(string path, TimeSpan expiryLength)
        {
            if (BucketName == null)
                throw new HttpResponseException(404);
            
            if (path == null)
                return string.Empty;

            var expiry = DateTime.UtcNow.Add(expiryLength);

            var request = new GetPreSignedUrlRequest
            {
                BucketName = BucketName,
                Key = path,
                Expires = expiry
            };

            return _s3.GetPreSignedURL(request);
        }
    }
}