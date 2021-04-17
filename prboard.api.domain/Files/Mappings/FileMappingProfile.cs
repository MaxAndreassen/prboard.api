using AutoMapper;
using prboard.api.data.Files.Entities;
using prboard.api.domain.Files.Models;

namespace prboard.api.domain.Files.Mappings
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<FileEntity, FileEditor>()
                .ForMember(t => t.File, a => a.Ignore());
        }
    }
}