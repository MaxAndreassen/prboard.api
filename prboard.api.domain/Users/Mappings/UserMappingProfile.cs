using AutoMapper;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Files.Contracts.Services;
using prboard.api.domain.Users.Models;

namespace prboard.api.domain.Users.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile(IPreSignedUrlGenerator preSignedUrlGenerator)
        {
            CreateMap<UserEntity, UserEditor>()
                .ForMember(t => t.ProfileImage, a => a.Ignore())
                .ForMember(t => t.ProfileUrl,
                    a => a.MapFrom(s => preSignedUrlGenerator.GetPreSignedUrl(s.ProfileImage.Url)))
                .ForMember(t => t.ExistingProfileUuid, a => a.MapFrom(s => s.ProfileImage.Uuid));

            CreateMap<UserSummaryPersonal, UserSummaryAnon>();

            CreateMap<UserEntity, UserSummaryPersonal>()
                .ForMember(t => t.ProfileUrl,
                    a => a.MapFrom(s => preSignedUrlGenerator.GetPreSignedUrl(s.ProfileImage.Url)))
                .ForMember(t => t.ExistingProfileUuid, a => a.MapFrom(s => s.ProfileImage.Uuid));

            CreateMap<UserEntity, UserSummaryAnon>()
                .ForMember(t => t.ProfileUrl,
                    a => a.MapFrom(s => preSignedUrlGenerator.GetPreSignedUrl(s.ProfileImage.Url)))
                .ForMember(t => t.ExistingProfileUuid, a => a.MapFrom(s => s.ProfileImage.Uuid));

            CreateMap<UserGitAccountEntity, UserGitAccountEntity>();
        }
    }
}