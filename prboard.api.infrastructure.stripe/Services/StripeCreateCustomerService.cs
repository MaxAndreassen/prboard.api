using System.Threading.Tasks;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using prboard.api.data.Users.Entities;
using prboard.api.domain.PaymentProviders.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeCreateCustomerService : IPaymentProviderCreateCustomerService
    {
        private readonly StripeConfig _stripeConfig;

        public StripeCreateCustomerService(
            IOptions<StripeConfig> stripeConfig
        )
        {
            _stripeConfig = stripeConfig.Value;
        }

        public async Task<string> CreateCustomerAsync(
            UserEntity user
        )
        {
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var options = new CustomerCreateOptions
            {
                Name = user.Name,
                Email = user.Email
            };

            var service = new CustomerService();
            var customer = await service.CreateAsync(options);

            return customer.Id;
        }
    }
}