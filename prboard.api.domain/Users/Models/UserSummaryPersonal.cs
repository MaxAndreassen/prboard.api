namespace prboard.api.domain.Users.Models
{
    public class UserSummaryPersonal : UserSummaryAnon
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}