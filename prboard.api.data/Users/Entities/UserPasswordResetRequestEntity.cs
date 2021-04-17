using foundation.Entities;

namespace prboard.api.data.Users.Entities
{
    public class UserPasswordResetRequestEntity : BaseEntity
    {
        public virtual UserEntity User { get; set; }
    }
}