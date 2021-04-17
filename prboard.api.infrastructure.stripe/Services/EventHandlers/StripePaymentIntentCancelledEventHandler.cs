using System;
using System.Threading.Tasks;
using foundation.Configuration;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripePaymentIntentCancelledEventHandler : IStripeEventHandler
    {
        public string EventType { get; } = Events.PaymentIntentCanceled;

        public StripePaymentIntentCancelledEventHandler()
        {
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

            var transactionUuidString = paymentIntent?.Metadata["TransactionUuid"];

            Guid.TryParse(transactionUuidString, out var transactionUuid);

            /*await _transactionUpdateService.ChangeTransactionStatusAsync(transactionUuid, TransactionStatus.Cancelled);*/
        }
    }
}