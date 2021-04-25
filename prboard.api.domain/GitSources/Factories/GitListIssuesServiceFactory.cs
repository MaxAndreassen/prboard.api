using System.Collections.Generic;
using System.Linq;
using foundation.Configuration;
using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Contracts.Factories;
using prboard.api.domain.GitSources.Contracts.Services;

namespace prboard.api.domain.GitSources.Factories
{
    [DomainService]
    public class GitListIssuesServiceFactory : IGitListIssuesServiceFactory
    {
        private readonly IEnumerable<IGitListIssuesService> _gitListIssuesServices;

        public GitListIssuesServiceFactory(IEnumerable<IGitListIssuesService> gitListIssuesServices)
        {
            _gitListIssuesServices = gitListIssuesServices;
        }
        
        public IGitListIssuesService Produce(GitAccountType type)
        {
            return _gitListIssuesServices.FirstOrDefault(p => p.Type == type);
        }
    }
}