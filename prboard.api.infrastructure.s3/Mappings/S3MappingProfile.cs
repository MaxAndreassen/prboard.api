using Amazon.S3.Model;
using AutoMapper;
using prboard.api.domain.Files.Models;

namespace prboard.api.infrastructure.s3.Mappings
{
    public class S3MappingProfile : Profile
    {
        public S3MappingProfile()
        {
            CreateMap<GetObjectResponse, FileResponse>()
                .ForMember(t => t.Path, a => a.MapFrom(s => s.Key))
                .ForMember(t => t.ResponseStream, a => a.Ignore());
            
            CreateMap<PutObjectResponse, FileResponse>()
                .ForMember(t => t.Path, a => a.Ignore())
                .ForMember(t => t.ResponseStream, a => a.Ignore());
        }
    }
}