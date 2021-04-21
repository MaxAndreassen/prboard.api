using System.Collections.Generic;
using System.Linq;
using foundation.Configuration;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Contracts.Factories;
using prboard.api.domain.Connections.Contracts.Services;

namespace prboard.api.domain.Connections.Factories
{
    [DomainService]
    public class GitGetUserServiceFactory : IGitGetUserServiceFactory
    {
        private readonly IEnumerable<IGitGetUserService> _gitGetUserServices;

        public GitGetUserServiceFactory(IEnumerable<IGitGetUserService> gitGetUserServices)
        {
            _gitGetUserServices = gitGetUserServices;
        }
        
        public IGitGetUserService Produce(GitAccountType type)
        {
            return _gitGetUserServices.FirstOrDefault(p => p.Type == type);
        }
    }
}