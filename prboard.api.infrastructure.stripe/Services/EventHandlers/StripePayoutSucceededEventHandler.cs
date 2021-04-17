using System.Threading.Tasks;
using foundation.Configuration;
using prboard.api.domain.Email.Contracts.Services;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripePayoutSucceededEventHandler : IStripeEventHandler
    {
        private readonly IPayoutCompleteEmailer _payoutCompleteEmailer;
        public string EventType { get; } = Events.PayoutCreated;

        public StripePayoutSucceededEventHandler(IPayoutCompleteEmailer payoutCompleteEmailer)
        {
            _payoutCompleteEmailer = payoutCompleteEmailer;
        }
        
        public Task HandleAsync(Event stripeEvent)
        {
            var payout = stripeEvent.Data.Object as Payout;
            var accountId = payout?.Metadata["AccountId"];
            var amount = payout?.Metadata["Amount"];
            
            _payoutCompleteEmailer.SendPayoutCompleteEmailAsync(accountId, amount, payout?.Id);
            
            return Task.CompletedTask;
        }
    }
}