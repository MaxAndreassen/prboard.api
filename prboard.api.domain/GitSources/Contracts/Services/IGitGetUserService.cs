using System.Threading.Tasks;
using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Models;

namespace prboard.api.domain.GitSources.Contracts.Services
{
    public interface IGitGetUserService
    {
        GitAccountType Type { get; }

        Task<GitUser> GetUserAsync(string accessToken);
    }
}