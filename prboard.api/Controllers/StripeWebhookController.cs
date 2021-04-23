using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using prboard.api.infrastructure.stripe;
using prboard.api.infrastructure.stripe.Services.Contracts;
using Sentry;
using Stripe;

namespace prboard.api.Controllers
{
    [Route("api/stripe")]
    public class StripeWebhookController : ControllerBase
    {
        private readonly IStripeEventStrategyzer _stripeEventStrategyzer;
        private readonly StripeConfig _stripeConfig;

        public StripeWebhookController(
            IOptions<StripeConfig> stripeConfigOptions,
            IStripeEventStrategyzer stripeEventStrategyzer
        )
        {
            _stripeEventStrategyzer = stripeEventStrategyzer;
            _stripeConfig = stripeConfigOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> StripeWebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    _stripeConfig.SecretSigningKey
                );

                var handler = _stripeEventStrategyzer.SelectHandler(stripeEvent.Type);

                if (handler != null)
                {
                    await handler.HandleAsync(stripeEvent);
                }
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return BadRequest();
            }
        }
    }
}