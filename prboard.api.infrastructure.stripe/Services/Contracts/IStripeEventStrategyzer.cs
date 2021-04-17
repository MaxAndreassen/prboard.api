namespace prboard.api.infrastructure.stripe.Services.Contracts
{
    public interface IStripeEventStrategyzer
    {
        IStripeEventHandler SelectHandler(string eventType);
    }
}