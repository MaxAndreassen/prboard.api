using System.IO.Compression;

namespace prboard.api.domain.Files.Contracts.Services
{
    public interface IZipContentReader
    {
        string ReadContent(ZipArchive archive);
    }
}