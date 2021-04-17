using System.Linq;
using System.Threading.Tasks;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using prboard.api.domain.PaymentProviders.Configuration;
using prboard.api.domain.PaymentProviders.Contracts;
using prboard.api.domain.PaymentProviders.Models;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeGetAccountBalanceService : IPaymentProviderAccountBalanceService
    {
        private readonly StripeConfig _stripeConfig;

        public StripeGetAccountBalanceService(
            IOptions<StripeConfig> stripeConfig
        )
        {
            _stripeConfig = stripeConfig.Value;
        }
        
        public async Task<PaymentProviderBalance> GetBalanceAsync(string accountId)
        {
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var service = new BalanceService();
            
            var requestOptions = new RequestOptions();
            requestOptions.StripeAccount = accountId == "admin" ? null : accountId;

            var balance = await service.GetAsync(requestOptions);

            var currentBalance = balance.Available.FirstOrDefault();

            var currency = currentBalance?.Currency ?? "gpb";
            var currentBalanceAmount = currentBalance?.Amount ?? 0;
            
            var pendingBalanceAmount = balance.Pending.FirstOrDefault()?.Amount ?? 0;

            return new PaymentProviderBalance
            {
                Balance = currentBalanceAmount,
                PendingBalance = pendingBalanceAmount,
                Currency = currency
            };
        }
    }
}