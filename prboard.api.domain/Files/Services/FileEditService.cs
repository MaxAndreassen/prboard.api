using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Files.Entities;
using prboard.api.data.Files.Enums;
using prboard.api.domain.Exceptions;
using prboard.api.domain.Files.Contracts.Services;
using prboard.api.domain.Files.Models;

namespace prboard.api.domain.Files.Services
{
    [DomainService]
    public class FileEditService : IFileEditService
    {
        private readonly IRepository<FileEntity> _fileRepository;
        private readonly IMapper _mapper;
        private readonly IExternalFileService _externalFileService;
        private readonly IFileTypeService _fileTypeService;

        public FileEditService(
            IRepository<FileEntity> fileRepository,
            IMapper mapper,
            IExternalFileService externalFileService,
            IFileTypeService fileTypeService
        )
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _externalFileService = externalFileService;
            _fileTypeService = fileTypeService;
        }

        public async Task<T> CreateOrUpdateAsync<T>(FileEditor editor) where T : class
        {
            if (editor?.File == null)
                throw new HttpResponseException(400);

            var entity = editor.Uuid == null
                ? _fileRepository.Create()
                : await _fileRepository
                    .FirstOrDefaultAsync(p => p.Uuid == editor.Uuid);

            var extension = Path.GetExtension(editor.File.FileName);

            var path = $"{entity.Uuid.ToString()}/{editor.File.Name}_{Guid.NewGuid()}_{extension}";

            using (var readStream = editor.File.OpenReadStream())
            using (var stream = new MemoryStream())
            {
                await readStream.CopyToAsync(stream);
                await _externalFileService.StoreAsync(path, stream);
            }

            entity.FileSize = editor.File.Length;
            entity.FileName = editor.File.FileName;
            entity.Extension = extension;
            entity.FileType = await _fileTypeService.GetFileTypeAsync(GetType(entity.Extension));
            entity.Url = path;

            return _mapper.Map<T>(entity);
        }

        FileType GetType(string extension)
        {
            if (string.IsNullOrEmpty(extension))
                throw new HttpResponseException(404, "No file extensions.");

            extension = extension.ToLower();

            switch (extension)
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                case ".svg":
                case ".gif":
                case ".heic":
                    return FileType.Image;
                case ".pdf":
                    return FileType.Pdf;
                case ".mp4":
                case ".mov":
                    return FileType.Video;
                case ".zip":
                    return FileType.Zip;
                default:
                    throw new HttpResponseException(404, $"{extension} not found.");
            }
        }
    }
}