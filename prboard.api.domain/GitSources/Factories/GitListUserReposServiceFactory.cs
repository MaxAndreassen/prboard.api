using System.Collections.Generic;
using System.Linq;
using foundation.Configuration;
using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Contracts.Factories;
using prboard.api.domain.GitSources.Contracts.Services;

namespace prboard.api.domain.GitSources.Factories
{
    [DomainService]
    public class GitListUserReposServiceFactory : IGitListUserReposServiceFactory
    {
        private readonly IEnumerable<IGitListUserReposService> _gitListUserReposServices;

        public GitListUserReposServiceFactory(IEnumerable<IGitListUserReposService> gitListUserReposServices)
        {
            _gitListUserReposServices = gitListUserReposServices;
        }

        public IGitListUserReposService Produce(GitAccountType type)
        {
            return _gitListUserReposServices.FirstOrDefault(p => p.Type == type);
        }
    }
}