using System.Threading.Tasks;

namespace prboard.api.domain.GitSources.Contracts.Services
{
    public interface IGetAccessTokenService
    {
        Task<string> GetAccessToken(string code);
    }
}