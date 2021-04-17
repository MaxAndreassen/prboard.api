using System;
using System.Threading.Tasks;
using prboard.api.data.Users.Entities;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserVerificationService
    {
        Task<UserEntity> VerifyAsync(Guid userVerificationRequestUuid);
    }
}