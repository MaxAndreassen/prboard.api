using System.Threading.Tasks;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Models;

namespace prboard.api.domain.Connections.Contracts.Services
{
    public interface IGitGetUserService
    {
        GitAccountType Type { get; }

        Task<GitUser> GetUserAsync(string accessToken);
    }
}