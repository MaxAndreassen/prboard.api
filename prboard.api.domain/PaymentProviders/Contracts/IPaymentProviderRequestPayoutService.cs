using System.Threading.Tasks;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderRequestPayoutService
    {
        Task RequestPayoutAsync(string accountId, int amount, string currency);
    }
}