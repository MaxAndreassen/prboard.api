using System.Collections.Generic;
using System.Threading.Tasks;
using prboard.api.domain.PaymentProviders.Models;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderPayoutListService
    {
        Task<IList<PaymentProviderPayout>> ListPayoutsAsync(string accountId, string startingAfter = null);
    }
}