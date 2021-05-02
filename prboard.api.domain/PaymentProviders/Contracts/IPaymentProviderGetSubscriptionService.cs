using System;
using System.Threading.Tasks;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderGetSubscriptionService
    {
        Task<string> GetSubscriptionForCustomerAsync(
            Guid userUuid
        );
    }
}