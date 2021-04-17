using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using Microsoft.Extensions.Options;
using prboard.api.domain.PaymentProviders.Configuration;
using prboard.api.domain.PaymentProviders.Contracts;
using prboard.api.domain.PaymentProviders.Models;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeCreatePaymentIntentService : IPaymentProviderCreatePaymentIntentService
    {
        private readonly IMapper _mapper;
        private readonly StripeConfig _stripeConfig;

        public StripeCreatePaymentIntentService(
            IOptions<StripeConfig> stripeConfig,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _stripeConfig = stripeConfig.Value;
        }

        public async Task<PaymentProviderPaymentIntent> CreatePaymentIntentAsync(
            string accountId,
            double amountInPence,
            Guid transactionUuid
        )
        {
            StripeConfiguration.ApiKey = _stripeConfig.ApiKey;

            var baseAmount = (int)Math.Round(amountInPence);
            var amount = (int) Math.Round(amountInPence * 1.2); // Apply VAT here later

            var service = new PaymentIntentService();
            var createOptions = new PaymentIntentCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                Amount = amount,
                Currency = "gbp",
                Metadata = new Dictionary<string, string>
                {
                    {"TransactionUuid", transactionUuid.ToString()},
                    {"DestinationAccount", accountId},
                    {"Amount", baseAmount.ToString()}
                },
                TransferGroup = transactionUuid.ToString()
            };

            var requestOptions = new RequestOptions
            {
                IdempotencyKey = transactionUuid.ToString()
            };

            var stripePaymentIntent = await service.CreateAsync(createOptions, requestOptions);

            return _mapper.Map<PaymentProviderPaymentIntent>(stripePaymentIntent);
        }
    }
}