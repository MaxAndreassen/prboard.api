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
    public class StripeInvoicePaidEventHandler : IStripeEventHandler
    {
        private readonly IRepository<UserEntity> _userRepository;
        
        public string EventType { get; } = Events.InvoicePaid;

        public StripeInvoicePaidEventHandler(
            IRepository<UserEntity> userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var invoice = stripeEvent.Data.Object as Invoice;

            var user = await _userRepository.FirstOrDefaultAsync(p => p.StripeCustomerId == invoice.CustomerId);

            //TODO: send confirmation of payment email.
        }
    }
}