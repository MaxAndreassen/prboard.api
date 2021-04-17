using System.Collections.Generic;
using System.Linq;
using foundation.Configuration;
using prboard.api.infrastructure.stripe.Services.Contracts;

namespace prboard.api.infrastructure.stripe.Services
{
    [DomainService]
    public class StripeEventStrategyzer : IStripeEventStrategyzer
    {
        private readonly IEnumerable<IStripeEventHandler> _stripeEventHandlers;

        public StripeEventStrategyzer(IEnumerable<IStripeEventHandler> stripeEventHandlers)
        {
            _stripeEventHandlers = stripeEventHandlers;
        }
        
        public IStripeEventHandler SelectHandler(string eventType)
        {
            return _stripeEventHandlers.FirstOrDefault(eventHandler => eventHandler.EventType == eventType);
        }
    }
}