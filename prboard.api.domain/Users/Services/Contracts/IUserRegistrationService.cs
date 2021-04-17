using System.Threading.Tasks;
using prboard.api.domain.Users.Requests;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserRegistrationService
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        
        Task<string> TestAsync();
    }
}