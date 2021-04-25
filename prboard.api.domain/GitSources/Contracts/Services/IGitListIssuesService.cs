using System.Collections.Generic;
using System.Threading.Tasks;
using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Models;

namespace prboard.api.domain.GitSources.Contracts.Services
{
    public interface IGitListIssuesService
    {
        GitAccountType Type { get; }

        Task<List<GitIssue>> GetIssuesForUserAsync(string accessToken);
    }
}