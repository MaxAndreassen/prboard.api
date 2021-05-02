using System;
using System.Linq;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using prboard.api.data.Users.Entities;
using prboard.api.domain.PaymentProviders.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeGetSubscriptionService : IPaymentProviderGetSubscriptionService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly StripeConfig _stripeConfig;

        public StripeGetSubscriptionService(
            IOptions<StripeConfig> stripeConfig,
            IRepository<UserEntity> userRepository
        )
        {
            _userRepository = userRepository;
            _stripeConfig = stripeConfig.Value;
        }

        public async Task<string> GetSubscriptionForCustomerAsync(
            Guid userUuid
        )
        {
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var user = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == userUuid);

            if (user?.StripeCustomerId == null)
                return null;
            
            var options = new SubscriptionListOptions
            {
                Customer = user.StripeCustomerId,
                Limit = 50
            };

            var service = new SubscriptionService();
            var subscriptions = await service
                .ListAsync(options);

            var validSubscriptions = subscriptions
                .Where(p => p.Status == "active" || p.Status == "trialing");

            return validSubscriptions.Any() ? "standard" : null;
        }
    }
}