using System.Threading.Tasks;

namespace prboard.api.domain.Connections.Contracts.Services
{
    public interface IGetAccessTokenService
    {
        Task<string> GetAccessToken(string code);
    }
}