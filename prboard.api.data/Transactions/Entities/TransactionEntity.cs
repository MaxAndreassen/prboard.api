using foundation.Entities;
using prboard.api.data.Transactions.Enums;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Transactions.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public virtual UserEntity PurchasingUser { get; set; }

        public double AmountInPence { get; set; }

        public TransactionStatus Status { get; set; }
        
        public string StripeId { get; set; }
        
        public string Identifier { get; set; }
    }
}