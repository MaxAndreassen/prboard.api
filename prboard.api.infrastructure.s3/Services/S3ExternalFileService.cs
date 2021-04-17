using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using prboard.api.domain.Exceptions;
using prboard.api.domain.Files.Configuration;
using prboard.api.domain.Files.Contracts.Services;
using prboard.api.domain.Files.Models;

namespace prboard.api.infrastructure.s3.Services
{
    [DomainService]
    public class S3ExternalFileService : IExternalFileService
    {
        private readonly IMapper _mapper;
        private readonly IAmazonS3 _s3;

        public S3ExternalFileService(
            IMapper mapper,
            IOptions<AwsConfig> awsOptions
        )
        {
            _mapper = mapper;

            _s3 = new AmazonS3Client(awsOptions.Value.Public,
                awsOptions.Value.Secret,
                RegionEndpoint.EUWest1
            );

            BucketName = awsOptions.Value.BucketName;
        }

        public string BucketName { get; set; }

        public async Task<FileResponse> GetAsync(string path)
        {
            if (string.IsNullOrEmpty(BucketName))
                throw new HttpResponseException(400);

            if (string.IsNullOrEmpty(path))
                throw new HttpResponseException(400);

            var request = new GetObjectRequest
            {
                BucketName = BucketName,
                Key = path
            };

            var awsResponse = await _s3.GetObjectAsync(request);

            var response = _mapper.Map<FileResponse>(awsResponse);

            using (var awsStream = awsResponse.ResponseStream)
            {
                response.ResponseStream = new MemoryStream(); //TODO: Ensure this doesn't leak
                await awsStream.CopyToAsync(response.ResponseStream);

                return response;
            }
        }

        public async Task<FileResponse> StoreAsync(
            string path,
            Stream stream
        )
        {
            if (string.IsNullOrEmpty(BucketName))
                throw new HttpResponseException(400);

            if (string.IsNullOrEmpty(path))
                throw new HttpResponseException(400);

            if (stream == null)
                throw new HttpResponseException(400);

            var request = new PutObjectRequest
            {
                BucketName = BucketName,
                InputStream = stream,
                Key = path,
                CannedACL = S3CannedACL.BucketOwnerFullControl
            };

            request.Headers.ContentLength = stream.Length;

            return _mapper.Map<FileResponse>(await _s3.PutObjectAsync(request));
        }

        public async Task<FileResponse> StoreAsync(
            string path,
            string content
        )
        {
            if (string.IsNullOrEmpty(BucketName))
                throw new HttpResponseException(400);

            if (string.IsNullOrEmpty(path))
                throw new HttpResponseException(400);

            if (content == null)
                throw new HttpResponseException(400);

            var request = new PutObjectRequest
            {
                BucketName = BucketName,
                ContentBody = content,
                Key = path,
                CannedACL = S3CannedACL.BucketOwnerFullControl
            };

            return _mapper.Map<FileResponse>(await _s3.PutObjectAsync(request));
        }

        public async Task DeleteAsync(string path)
        {
            if (string.IsNullOrEmpty(BucketName))
                throw new HttpResponseException(400);

            if (string.IsNullOrEmpty(path))
                throw new HttpResponseException(400);

            await _s3.DeleteObjectAsync(BucketName, path);
        }
    }
}