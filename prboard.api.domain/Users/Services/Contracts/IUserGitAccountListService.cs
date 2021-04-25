using System.Collections.Generic;
using System.Threading.Tasks;
using prboard.api.domain.Users.Models;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserGitAccountListService
    {
        Task<IList<T>> ListUserGitAccountsAsync<T>(UserGitAccountQueryParams request) where T : class;
    }
}