using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Email.Services;
using prboard.api.domain.Exceptions;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripePayoutCreatedEventHandler : IStripeEventHandler
    {
        public string EventType { get; } = Events.PayoutCreated;
        
        private readonly IRepository<UserEntity> _userRepository;

        public StripePayoutCreatedEventHandler(
            IRepository<UserEntity> userRepository
        )
        {

            _userRepository = userRepository;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var payout = stripeEvent.Data.Object as Payout;
            var accountId = payout?.Metadata["AccountId"];
            var amount = payout?.Metadata["Amount"];

            var user = await _userRepository
                .FirstOrDefaultAsync(p => p.StripeAccountId == accountId);
            
            if (user == null)
            {
                throw new HttpResponseException(404);
            }
            
            BackgroundJob.Enqueue<PayoutRequestEmailer>(e =>
                e.SendPayoutRequestedEmailAsync(accountId,  amount, payout.Id)
            );
        }
    }
}