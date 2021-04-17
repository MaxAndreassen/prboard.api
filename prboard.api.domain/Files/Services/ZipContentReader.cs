using System.IO.Compression;
using System.Linq;
using foundation.Configuration;
using prboard.api.domain.Files.Contracts.Services;

namespace prboard.api.domain.Files.Services
{
    [DomainService]
    public class ZipContentReader : IZipContentReader
    {
        public string ReadContent(ZipArchive archive)
        {
            var contents = archive.Entries
                .Where(entry => !entry.FullName.EndsWith("/") && !entry.Name.Contains("game_asset_license"))
                .Aggregate("", (current, entry) => current + $"{entry.FullName}?{entry.Length}|");

            if (!string.IsNullOrEmpty(contents))
                contents = contents.Substring(0, contents.Length - 1);

            return contents;
        }
    }
}