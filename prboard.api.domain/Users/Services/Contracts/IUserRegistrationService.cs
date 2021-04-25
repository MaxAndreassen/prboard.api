using System.Threading.Tasks;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Requests;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserRegistrationService
    {
        Task<UserEntity> RegisterAsync(RegistrationRequest request);
    }
}