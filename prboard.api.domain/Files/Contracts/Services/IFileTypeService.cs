using System.Threading.Tasks;
using prboard.api.data.Files.Entities;
using prboard.api.data.Files.Enums;

namespace prboard.api.domain.Files.Contracts.Services
{
    public interface IFileTypeService
    {
        Task<FileTypeEntity> GetFileTypeAsync(FileType type);
    }
}