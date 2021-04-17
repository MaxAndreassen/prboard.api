using System.Collections.Generic;
using System.Threading.Tasks;
using prboard.api.domain.PaymentProviders.Models;

namespace prboard.api.domain.PaymentProviders.Contracts
{
    public interface IPaymentProviderAccountTransferListService
    {
        Task<IList<PaymentProviderTransfer>> ListTransfersAsync(string accountId, string startingAfter = null);
    }
}