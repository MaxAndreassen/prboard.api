using System.Threading.Tasks;

namespace prboard.api.domain.Email.Contracts.Services
{
    public interface IPayoutCompleteEmailer
    {
        Task SendPayoutCompleteEmailAsync(
            string accountId,
            string payoutAmount,
            string payoutId
        );
    }
}