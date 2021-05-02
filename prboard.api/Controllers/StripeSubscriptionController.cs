using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prboard.api.domain.PaymentProviders.Contracts;
using prboard.api.domain.PaymentProviders.Models;

namespace prboard.api.Controllers
{
    [Route("api/stripe-sub")]
    [ApiController]
    public class StripeSubscriptionController : ControllerBase
    {
        private readonly IPaymentProviderCreateCheckoutSessionService _paymentProviderCreateCheckoutSessionService;
        private readonly IPaymentProviderGetSubscriptionService _paymentProviderGetSubscriptionService;

        public StripeSubscriptionController(
            IPaymentProviderCreateCheckoutSessionService paymentProviderCreateCheckoutSessionService,
            IPaymentProviderGetSubscriptionService paymentProviderGetSubscriptionService
        )
        {
            _paymentProviderCreateCheckoutSessionService = paymentProviderCreateCheckoutSessionService;
            _paymentProviderGetSubscriptionService = paymentProviderGetSubscriptionService;
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

        [HttpGet("{userUuid}")]
        public async Task<IActionResult> GetSubscriptionForUserAsync([FromRoute] Guid userUuid)
        {
            var plan = await _paymentProviderGetSubscriptionService.GetSubscriptionForCustomerAsync(userUuid);

            var planModel = new SubscriptionPlan
            {
                UserUuid = userUuid,
                Plan = plan
            };

            return Ok(planModel);
        }
    }
}