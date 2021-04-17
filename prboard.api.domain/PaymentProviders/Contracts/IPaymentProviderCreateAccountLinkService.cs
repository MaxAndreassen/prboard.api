using System.Threading.Tasks;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderCreateAccountLinkService
    {
        Task<string> CreateAccountLinkAsync(string accountId, string returnLocation);
    }
}