using AutoMapper;
using prboard.api.domain.GitSources.Models;
using prboard.api.infrastructure.github.Models;

namespace prboard.api.infrastructure.github.Mappings
{
    public class GitHubMappingProfile : Profile
    {
        public GitHubMappingProfile()
        {
            CreateMap<GitHubUser, GitUser>()
                .ForMember(t => t.Name, a => a.MapFrom(s => s.Name))
                .ForMember(t => t.Username, a => a.MapFrom(s => s.Login))
                .ForMember(t => t.Company, a => a.MapFrom(s => s.Company))
                .ForMember(t => t.AvatarUrl, a => a.MapFrom(s => s.AvatarUrl))
                .ForMember(t => t.PrivateRepoCount, a => a.MapFrom(s => s.TotalPrivateRepos))
                .ForMember(t => t.PublicRepoCount, a => a.MapFrom(s => s.PublicRepos))
                .ForMember(t => t.Source, a => a.MapFrom(s => "github"))
                .ForMember(t => t.Id, a => a.MapFrom(s => s.NodeId))
                .ForMember(t => t.Email, a => a.MapFrom(s => s.Email));

            CreateMap<GitHubRepo, GitRepo>()
                .ForMember(t => t.Name, a => a.MapFrom(s => s.Name))
                .ForMember(t => t.OwnerName, a => a.MapFrom(s => s.Owner.Name))
                .ForMember(t => t.Id, a => a.MapFrom(s => s.NodeId))
                .ForMember(t => t.Description, a => a.MapFrom(s => s.Description))
                .ForMember(t => t.OpenIssuesCount, a => a.MapFrom(s => s.OpenIssuesCount))
                .ForMember(t => t.Source, a => a.MapFrom(s => "github"))
                .ForMember(t => t.AvatarUrl, a => a.MapFrom(s => s.Owner.AvatarUrl));

            CreateMap<GitHubIssue, GitIssue>()
                .ForMember(t => t.RepositoryId, a => a.MapFrom(s => s.Repository.NodeId))
                .ForMember(t => t.PullRequestUrl, a => a.MapFrom(s => s.PullRequest.Url));
        }
    }
}