using System.Threading.Tasks;
using Stripe;

namespace prboard.api.infrastructure.stripe.Services.Contracts
{
    public interface IStripeEventHandler
    {
        string EventType { get; }
        
        Task HandleAsync(Event stripeEvent);
    }
}