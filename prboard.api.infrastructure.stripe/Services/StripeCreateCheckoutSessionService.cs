using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using prboard.api.domain;
using prboard.api.domain.PaymentProviders.Contracts;
using prboard.api.domain.PaymentProviders.Models;
using prboard.api.domain.Users.Services.Contracts;
using Stripe;
using Stripe.Checkout;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeCreateCheckoutSessionService : IPaymentProviderCreateCheckoutSessionService
    {
        private readonly ISecurityService _securityService;
        private readonly LinkConfig _linkConfig;
        private readonly StripeConfig _stripeConfig;

        public StripeCreateCheckoutSessionService(
            IOptions<StripeConfig> stripeConfig,
            IOptions<LinkConfig> linkConfig,
            ISecurityService securityService
        )
        {
            _securityService = securityService;
            _linkConfig = linkConfig.Value;
            _stripeConfig = stripeConfig.Value;
        }

        public async Task<PaymentProviderCheckoutSession> CreateCheckoutSessionAsync(
            PaymentProviderCheckoutSessionRequest request
            )
        {
            var user = await _securityService.GetCurrentUserAsync();
            
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var options = new SessionCreateOptions
            {
                SuccessUrl = _linkConfig.PlatformBaseUrl + "plans/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = _linkConfig.PlatformBaseUrl + "/plans",
                PaymentMethodTypes = new List<string> {"card"},
                Mode = "subscription",
                Customer = user.StripeCustomerId,
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = request.PriceId,
                        Quantity = 1
                    }
                }
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return new PaymentProviderCheckoutSession
            {
                SessionId = session.Id
            };
        }
    }
}