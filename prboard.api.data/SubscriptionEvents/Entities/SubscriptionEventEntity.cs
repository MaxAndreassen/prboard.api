using System;
using foundation.Entities;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.SubscriptionEvents.Entities
{
    public class SubscriptionEventEntity : BaseEntity
    {
        public virtual UserEntity User { get; set; }
        
        public string Plan { get; set; }
        
        public DateTime ValidUntil { get; set; }
        
        public bool Failure { get; set; }
    }
}