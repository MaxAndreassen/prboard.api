using System.Threading.Tasks;
using prboard.api.domain.Files.Models;

namespace prboard.api.domain.Files.Contracts.Services
{
    public interface IFileEditService
    {
        Task<T> CreateOrUpdateAsync<T>(FileEditor editor) where T : class;
    }
}