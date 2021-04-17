using System.Threading.Tasks;
using prboard.api.data.Users.Entities;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderCreateAccountService
    {
        Task<string> CreateAccountAsync(UserEntity user);
    }
}