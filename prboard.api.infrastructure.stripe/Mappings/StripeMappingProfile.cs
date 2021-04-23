using AutoMapper;
using prboard.api.domain.PaymentProviders.Models;
using Stripe;

namespace prboard.api.infrastructure.stripe.Mappings
{
    public class StripeMappingProfile : Profile
    {
        public StripeMappingProfile()
        {
        }
    }
}