using foundation.Entities;

namespace prboard.api.data.Users.Entities
{
    public class UserVerificationRequestEntity : BaseEntity
    {
        public virtual UserEntity User { get; set; }
    }
}