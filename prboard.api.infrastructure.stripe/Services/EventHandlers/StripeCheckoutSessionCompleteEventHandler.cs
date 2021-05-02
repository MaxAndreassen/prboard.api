using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;
using Stripe.Checkout;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripeCheckoutSessionCompleteEventHandler : IStripeEventHandler
    {
        private readonly IRepository<UserEntity> _userRepository;
        
        public string EventType { get; } = Events.CheckoutSessionCompleted;

        public StripeCheckoutSessionCompleteEventHandler(
            IRepository<UserEntity> userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var checkoutSession = stripeEvent.Data.Object as Session;

            var user = await _userRepository.FirstOrDefaultAsync(p => p.StripeCustomerId == checkoutSession.CustomerId);
            
            /* send email to user */
        }
    }
}