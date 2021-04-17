using foundation.Entities;

namespace prboard.api.data.Users.Entities
{
    public class UserCreditEntity : BaseEntity
    {
        public virtual UserEntity User { get; set; }

        public int CreditChangeInPence { get; set; }
    }
}