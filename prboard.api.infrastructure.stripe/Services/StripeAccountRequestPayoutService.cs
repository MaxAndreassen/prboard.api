using System.Collections.Generic;
using System.Threading.Tasks;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using prboard.api.domain.PaymentProviders.Configuration;
using prboard.api.domain.PaymentProviders.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeAccountRequestPayoutService : IPaymentProviderRequestPayoutService
    {
        private readonly StripeConfig _stripeConfig;

        public StripeAccountRequestPayoutService(
            IOptions<StripeConfig> stripeConfig
        )
        {
            _stripeConfig = stripeConfig.Value;
        }

        public async Task RequestPayoutAsync(string accountId, int amount, string currency)
        {
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var service = new PayoutService();

            var requestOptions = new RequestOptions
            {
                StripeAccount = accountId == "admin" ? null : accountId
            };

            var options = new PayoutCreateOptions
            {
                Amount = amount,
                Currency = currency,
                Metadata = new Dictionary<string, string>
                {
                    {"AccountId", accountId},
                    {"Amount", amount.ToString()}
                }
            };

            await service.CreateAsync(options, requestOptions);
        }
    }
}