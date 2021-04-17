using System;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Files.Contracts.Services;

namespace prboard.api.domain.Files.Services
{
    [DomainService]
    public class FileDeleteService : IFileDeleteService
    {
        private readonly IRepository<UserEntity> _userRepository;

        public FileDeleteService(
            IRepository<UserEntity> userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task DeleteByUserAsync(Guid userUuid)
        {
            var user = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == userUuid);

            var entity = user?.ProfileImage;

            if (entity == null)
                return;

            entity.DeletedAt = DateTime.Now;
        }
    }
}