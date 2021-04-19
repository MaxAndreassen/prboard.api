using System.Threading.Tasks;
using prboard.api.domain.Users.Models;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserGitAccountEditService
    {
        Task<T> UpdateAsync<T>(UserGitAccountEditor editor) where T : class;
    }
}