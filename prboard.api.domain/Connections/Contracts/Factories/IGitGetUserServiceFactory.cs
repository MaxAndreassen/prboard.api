using prboard.api.data.Users.Enums;
using prboard.api.domain.Connections.Contracts.Services;

namespace prboard.api.domain.Connections.Contracts.Factories
{
    public interface IGitGetUserServiceFactory
    {
        IGitGetUserService Produce(GitAccountType type);
    }
}