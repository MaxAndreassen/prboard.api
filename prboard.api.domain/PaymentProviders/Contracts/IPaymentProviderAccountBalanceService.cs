using System.Threading.Tasks;
using prboard.api.domain.PaymentProviders.Models;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderAccountBalanceService
    {
        Task<PaymentProviderBalance> GetBalanceAsync(string accountId);
    }
}