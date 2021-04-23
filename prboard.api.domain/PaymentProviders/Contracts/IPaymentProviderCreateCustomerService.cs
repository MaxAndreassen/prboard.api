using System.Threading.Tasks;
using prboard.api.data.Users.Entities;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderCreateCustomerService
    {
        Task<string> CreateCustomerAsync(
            UserEntity user
        );
    }
}