using foundation.Entities;
using prboard.api.data.Users.Enums;

namespace prboard.api.data.Users.Entities
{
    public class UserTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public UserType Type { get; set; }
    }
}