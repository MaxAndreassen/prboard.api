using System.Threading.Tasks;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Requests;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface ILoginService
    {
        Task<string> GenerateTokenAsync(int userId);

        Task<UserEntity> GetUserAsync(LoginRequest request);
    }
}