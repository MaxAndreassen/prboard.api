using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using prboard.api.data.Transactions.Entities;
using prboard.api.data.Transactions.Enums;
using prboard.api.domain.Exceptions;
using prboard.api.domain.PaymentProviders.Configuration;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services.EventHandlers
{
    [DomainService]
    public class StripePaymentIntentSucceededEventHandler : IStripeEventHandler
    {
        public string EventType { get; } = Events.PaymentIntentSucceeded;
        
        private readonly IRepository<TransactionEntity> _transactionRepository;
        private readonly IOptions<StripeConfig> _stripeConfig;

        public StripePaymentIntentSucceededEventHandler(
            IRepository<TransactionEntity> transactionRepository,
            IOptions<StripeConfig> stripeConfig
        )
        {
            _transactionRepository = transactionRepository;
            _stripeConfig = stripeConfig;
        }

        public async Task HandleAsync(Event stripeEvent)
        {
            StripeConfiguration.ApiKey = _stripeConfig.Value.ApiKey;
            
            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

            var transactionUuidString = paymentIntent?.Metadata["TransactionUuid"];
            var destinationAccount = paymentIntent?.Metadata["DestinationAccount"];
            var parsed = int.TryParse(paymentIntent?.Metadata["Amount"], out var amount);

            if (!parsed)
            {
                throw new HttpResponseException(400);
            }

            Guid.TryParse(transactionUuidString, out var transactionUuid);

            // await _transactionUpdateService.ChangeTransactionStatusAsync(transactionUuid, TransactionStatus.Succeeded);

            /* var purchaser = await _transactionRepository
                .Include(p => p.PurchasingUser)
                .ThenInclude(p => p.AffiliateUsed)
                .Where(p => p.Uuid == transactionUuid)
                .Select(p => p.PurchasingUser)
                .FirstOrDefaultAsync(); */

            var transferService = new TransferService();

            /*BackgroundJob.Enqueue<OrderConfirmedEmailer>(e =>
                e.SendOrderConfirmedEmailAsync(transactionUuid, paymentIntent.Id)
            );*/
        }
    }
}