using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Contracts.Services;

namespace prboard.api.domain.Connections.Contracts.Factories
{
    public interface IGitListUserReposServiceFactory
    {
        IGitListUserReposService Produce(GitAccountType type);
    }
}