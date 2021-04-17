using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Files.Entities;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Files.Contracts.Services;
using prboard.api.domain.Files.Models;
using prboard.api.domain.Users.Models;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class UserEditService : IUserEditService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IFileEditService _fileEditService;
        private readonly IFileDeleteService _fileDeleteService;
        private readonly IWorkUnit _workUnit;
        private readonly IMapper _mapper;

        public UserEditService(
            IRepository<UserEntity> userRepository,
            ISecurityService securityService,
            IFileEditService fileEditService,
            IFileDeleteService fileDeleteService,
            IWorkUnit workUnit,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _fileEditService = fileEditService;
            _fileDeleteService = fileDeleteService;
            _workUnit = workUnit;
            _mapper = mapper;
        }

        public async Task<T> UpdateAsync<T>(UserEditor editor) where T : class
        {
            var currentUser = await _securityService.GetCurrentUserAsync();

            if (editor.Uuid != currentUser.Uuid)
                return null;

            var entity = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == editor.Uuid);

            if (entity == null)
                return null;

            if (editor.ExistingProfileUuid == null)
                await _fileDeleteService.DeleteByUserAsync(editor.Uuid);

            if (editor.ProfileImage != null)
            {
                var fileEditor = new FileEditor
                {
                    File = editor.ProfileImage
                };

                var savedFileEntity = await _fileEditService.CreateOrUpdateAsync<FileEntity>(fileEditor);

                entity.ProfileImage = savedFileEntity;
            }

            entity.Username = editor.Username;
            entity.FirstName = editor.FirstName;
            entity.LastName = editor.LastName;
            entity.CompanyName = editor.CompanyName;

            await _workUnit.CommitAsync();

            return _mapper.Map<T>(entity);
        }

        public async Task ChangePasswordAsync(UserEntity entity, string newPassword)
        {
            if (!string.IsNullOrEmpty(newPassword))
                entity.ChangePassword(newPassword);

            await _workUnit.CommitAsync();
        }
    }
}