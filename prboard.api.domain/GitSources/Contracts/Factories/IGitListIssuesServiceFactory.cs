using prboard.api.data.Users.Enums;
using prboard.api.domain.GitSources.Contracts.Services;

namespace prboard.api.domain.GitSources.Contracts.Factories
{
    public interface IGitListIssuesServiceFactory
    {
        IGitListIssuesService Produce(GitAccountType type);
    }
}