using System;

namespace prboard.api.domain.SubscriptionEvents.Models
{
    public class SubscriptionEventEditor
    {
        public Guid? Uuid { get; set; }
        
        public Guid UserUuid { get; set; }
        
        public string Plan { get; set; }
        
        public DateTime ValidUntil { get; set; }
        
        public bool Failure { get; set; }
    }
}