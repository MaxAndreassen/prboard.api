using System;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripeInvoicePaymentFailedEventHandler : IStripeEventHandler
    {
        private readonly IRepository<UserEntity> _userRepository;
        
        public string EventType { get; } = Events.InvoicePaymentFailed;

        public StripeInvoicePaymentFailedEventHandler(
            IRepository<UserEntity> userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var invoice = stripeEvent.Data.Object as Invoice;

            var user = await _userRepository.FirstOrDefaultAsync(p => p.StripeCustomerId == invoice.CustomerId);

            //TODO: send email linking to Stripe Subscription management dashboard for customer to update payment info.
        }
    }
}