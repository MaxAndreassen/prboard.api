using System.Threading.Tasks;
using prboard.api.domain.SubscriptionEvents.Models;

namespace prboard.api.domain.SubscriptionEvents.Contracts.Services
{
    public interface ISubscriptionEventCreateService
    {
        Task CreateSubscriptionAsync(SubscriptionEventEditor eventEditor);
    }
}