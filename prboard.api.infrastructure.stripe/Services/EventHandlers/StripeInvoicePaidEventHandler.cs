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

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripeInvoicePaidEventHandler : IStripeEventHandler
    {
        private readonly ISubscriptionEventCreateService _subscriptionEventCreateService;
        private readonly IRepository<UserEntity> _userRepository;
        
        public string EventType { get; } = Events.InvoicePaid;

        public StripeInvoicePaidEventHandler(
            ISubscriptionEventCreateService subscriptionEventCreateService,
            IRepository<UserEntity> userRepository
        )
        {
            _subscriptionEventCreateService = subscriptionEventCreateService;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var invoice = stripeEvent.Data.Object as Invoice;

            var user = await _userRepository.FirstOrDefaultAsync(p => p.StripeCustomerId == invoice.CustomerId);

            var subscriptionEditor = new SubscriptionEventEditor
            {
                Plan = invoice?.SubscriptionId, UserUuid = user.Uuid, ValidUntil = DateTime.Now.AddMonths(1)
            };

            await _subscriptionEventCreateService.CreateSubscriptionAsync(subscriptionEditor);
            
            //TODO: send confirmation of payment email.
        }
    }
}