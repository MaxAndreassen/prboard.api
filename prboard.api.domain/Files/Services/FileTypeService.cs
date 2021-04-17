using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Files.Entities;
using prboard.api.data.Files.Enums;
using prboard.api.domain.Files.Contracts.Services;

namespace prboard.api.domain.Files.Services
{
    [DomainService]
    public class FileTypeService : IFileTypeService
    {
        private readonly IRepository<FileTypeEntity> _fileTypeRepository;

        public FileTypeService(
            IRepository<FileTypeEntity> fileTypeRepository
            )
        {
            _fileTypeRepository = fileTypeRepository;
        }

        public async Task<FileTypeEntity> GetFileTypeAsync(FileType type)
        {
            return await _fileTypeRepository.FirstOrDefaultAsync(p => p.Type == type);
        }
    }
}