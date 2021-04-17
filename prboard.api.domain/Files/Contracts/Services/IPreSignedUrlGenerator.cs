using System;

namespace prboard.api.domain.Files.Contracts.Services
{
    public interface IPreSignedUrlGenerator
    {
        string GetPreSignedUrl(string path);

        string GetPreSignedUrl(string path, TimeSpan expiryLength);
    }
}