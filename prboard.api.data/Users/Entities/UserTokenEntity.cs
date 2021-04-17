using System;
using foundation.Entities;

namespace prboard.api.data.Users.Entities
{
    public class UserTokenEntity : BaseEntity
    {
        public string Token { get; set; }

        public DateTime ExpiresAt { get; set; }

        public virtual UserEntity User { get; set; }
    }
}