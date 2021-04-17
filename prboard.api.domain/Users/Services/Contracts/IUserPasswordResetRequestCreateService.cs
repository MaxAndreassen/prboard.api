using System.Threading.Tasks;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserPasswordResetRequestCreateService
    {
        Task CreateAsync(string email);
    }
}