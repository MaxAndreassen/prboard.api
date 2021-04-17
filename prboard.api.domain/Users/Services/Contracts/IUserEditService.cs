using System.Threading.Tasks;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Models;

namespace prboard.api.domain.Users.Services.Contracts
{
    public interface IUserEditService
    {
        Task<T> UpdateAsync<T>(UserEditor editor) where T : class;

        Task ChangePasswordAsync(UserEntity entity, string newPassword);
    }
}