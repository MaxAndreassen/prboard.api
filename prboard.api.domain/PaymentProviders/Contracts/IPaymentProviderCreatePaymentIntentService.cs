using System;
using System.Threading.Tasks;
using prboard.api.domain.PaymentProviders.Models;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderCreatePaymentIntentService
    {
        Task<PaymentProviderPaymentIntent> CreatePaymentIntentAsync(
            string accountId,
            double amountInPence,
            Guid transactionUuid
        );
    }
}