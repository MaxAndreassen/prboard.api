using System.Threading.Tasks;

namespace prboard.api.domain.Email.Contracts.Services
{
    public interface IPayoutRequestEmailer
    {
        Task SendPayoutRequestedEmailAsync(
            string accountId,
            string payoutAmount,
            string payoutId
        );
    }
}