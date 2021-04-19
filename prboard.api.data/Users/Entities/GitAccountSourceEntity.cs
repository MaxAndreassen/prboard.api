using foundation.Entities;
using prboard.api.data.Users.Enums;

namespace prboard.api.data.Users.Entities
{
    public class GitAccountSourceEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public GitAccountType Type { get; set; }
    }
}