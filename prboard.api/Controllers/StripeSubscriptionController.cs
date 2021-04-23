using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prboard.api.domain.PaymentProviders.Contracts;
using prboard.api.domain.PaymentProviders.Models;
using prboard.api.domain.Users.Requests;

namespace prboard.api.Controllers
{
    [Route("api/stripe-sub")]
    [ApiController]
    public class StripeSubscriptionController : ControllerBase
    {
        private readonly IPaymentProviderCreateCheckoutSessionService _paymentProviderCreateCheckoutSessionService;

        public StripeSubscriptionController(
            IPaymentProviderCreateCheckoutSessionService paymentProviderCreateCheckoutSessionService
        )
        {
            _paymentProviderCreateCheckoutSessionService = paymentProviderCreateCheckoutSessionService;
        }

        [HttpPost]
        [Route("create-session")]
        public async Task<IActionResult> CreateCheckoutSessionAsync(
            [FromBody] PaymentProviderCheckoutSessionRequest request
        )
        {
            var result = await _paymentProviderCreateCheckoutSessionService
                .CreateCheckoutSessionAsync(request);

            return Ok(result);
        }
    }
}