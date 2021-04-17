namespace prboard.api.domain.Users.Models
{
    public class UserSummaryPersonal : UserSummaryAnon
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }
    }
}