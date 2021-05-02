using System;

namespace prboard.api.domain.PaymentProviders.Models
{
    public class SubscriptionPlan
    {
        public Guid UserUuid { get; set; }
        
        public string Plan { get; set; }
    }
}