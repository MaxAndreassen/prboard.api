using System;
using System.Linq;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Exceptions;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class UserVerificationService : IUserVerificationService
    {
        private readonly IRepository<UserVerificationRequestEntity> _userVerificationRequestRepository;
        private readonly IWorkUnit _workUnit;

        public UserVerificationService(
            IRepository<UserVerificationRequestEntity> userVerificationRequestRepository,
            IWorkUnit workUnit
            )
        {
            _userVerificationRequestRepository = userVerificationRequestRepository;
            _workUnit = workUnit;
        }
        
        public async Task<UserEntity> VerifyAsync(Guid userVerificationRequestUuid)
        {
            var entity = await _userVerificationRequestRepository
                .Include(p => p.User)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync(p => p.Uuid == userVerificationRequestUuid && p.DeletedAt == null);
            
            if (entity == null)
                throw new HttpResponseException(404);

            entity.User.IsEmailVerified = true;

            await _workUnit.CommitAsync();

            return entity.User;
        }
    }
}