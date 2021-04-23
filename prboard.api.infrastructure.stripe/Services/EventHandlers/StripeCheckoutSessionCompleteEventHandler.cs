using System;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.SubscriptionEvents.Contracts.Services;
using prboard.api.domain.SubscriptionEvents.Models;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;
using Stripe.Checkout;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripeCheckoutSessionCompleteEventHandler : IStripeEventHandler
    {
        private readonly ISubscriptionEventCreateService _subscriptionEventCreateService;
        private readonly IRepository<UserEntity> _userRepository;
        
        public string EventType { get; } = Events.CheckoutSessionCompleted;

        public StripeCheckoutSessionCompleteEventHandler(
            ISubscriptionEventCreateService subscriptionEventCreateService,
            IRepository<UserEntity> userRepository
        )
        {
            _subscriptionEventCreateService = subscriptionEventCreateService;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var checkoutSession = stripeEvent.Data.Object as Session;

            var user = await _userRepository.FirstOrDefaultAsync(p => p.StripeCustomerId == checkoutSession.CustomerId);

            var subscriptionEditor = new SubscriptionEventEditor
            {
                Plan = checkoutSession?.SubscriptionId, UserUuid = user.Uuid, ValidUntil = DateTime.Now.AddMonths(1)
            };

            await _subscriptionEventCreateService.CreateSubscriptionAsync(subscriptionEditor);
        }
    }
}