using System.Collections.Generic;
using System.Threading.Tasks;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Models;

namespace prboard.api.domain.Connections.Contracts.Services
{
    public interface IGitListUserReposService
    {
        GitAccountType Type { get; }

        Task<List<GitRepo>> GetRepositoriesForUserAsync(string accessToken, string username);
    }
}