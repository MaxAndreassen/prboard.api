using System;
using System.Threading.Tasks;
using prboard.api.domain.Users.Models;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserGetService
    {
        Task<T> GetAsync<T>(Guid uuid) where T : UserSummaryAnon;
    }
}