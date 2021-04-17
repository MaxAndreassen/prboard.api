namespace prboard.api.domain.Users.Requests
{
    public class UserListRequest
    {
        public int? Page { get; set; }
        
        public int PageSize { get; set; }
    }
}