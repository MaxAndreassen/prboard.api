using System;
using System.Threading.Tasks;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserVerificationRequestCreateService
    {
        Task CreateUserVerificationRequestAsync(Guid userUuid);
    }
}