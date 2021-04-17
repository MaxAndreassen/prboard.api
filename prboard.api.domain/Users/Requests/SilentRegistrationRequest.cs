using System;

namespace prboard.api.domain.Users.Requests
{
    public class SilentRegistrationRequest
    {
        public string Email { get; set; }
        
        public Guid? RelatedTournamentUuid { get; set; }
    }
}