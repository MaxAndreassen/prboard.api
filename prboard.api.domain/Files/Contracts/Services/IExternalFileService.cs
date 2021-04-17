using System.IO;
using System.Threading.Tasks;
using prboard.api.domain.Files.Models;

namespace prboard.api.domain.Files.Contracts.Services
{
    public interface IExternalFileService
    {
        Task<FileResponse> GetAsync(string path);

        Task<FileResponse> StoreAsync(
            string path,
            Stream stream
        );

        Task<FileResponse> StoreAsync(
            string path,
            string content
        );

        Task DeleteAsync(string path);
    }
}