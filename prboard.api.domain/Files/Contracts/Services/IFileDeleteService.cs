using System;
using System.Threading.Tasks;

namespace prboard.api.domain.Files.Contracts.Services
{
    public interface IFileDeleteService
    {
        Task DeleteByUserAsync(Guid userUuid);
    }
}