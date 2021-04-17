using System.Collections.Generic;
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
    public class StripePayoutListService : IPaymentProviderPayoutListService
    {
        private readonly StripeConfig _stripeConfig;

        public StripePayoutListService(
            IOptions<StripeConfig> stripeConfig
        )
        {
            _stripeConfig = stripeConfig.Value;
        }
        
        public async Task<IList<PaymentProviderPayout>> ListPayoutsAsync(string accountId, string startingAfter = null)
        {
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var options = new PayoutListOptions
            {
                Limit = 100
            };

            var requestOptions = new RequestOptions
            {
                StripeAccount =  accountId == "admin" ? null : accountId
            };

            if (!string.IsNullOrEmpty(startingAfter))
                options.StartingAfter = startingAfter;

            var service = new PayoutService();
            
            var payouts = await service.ListAsync(
                options,
                requestOptions
            );

            var returnables = new List<PaymentProviderPayout>();
            
            foreach (var payout in payouts)
            {
                var returnable = new PaymentProviderPayout
                {
                    Amount = payout.Amount,
                    DestinationUserStripeId = payout.DestinationId,
                    CreatedAt = payout.Created.ToString("g"),
                    Id = payout.Id,
                    Status = payout.Status
                };
                
                returnables.Add(returnable);
            }

            return returnables;
        }
    }
}