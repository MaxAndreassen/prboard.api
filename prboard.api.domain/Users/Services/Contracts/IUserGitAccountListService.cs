using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserGitAccountListService
    {
        Task<IList<T>> ListUserGitAccountsAsync<T>(Guid? userUuid) where T : class;
    }
}