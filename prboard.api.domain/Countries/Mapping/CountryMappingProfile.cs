using AutoMapper;
using prboard.api.data.Countries.Entities;
using prboard.api.domain.Countries.Models;

namespace prboard.api.domain.Countries.Mapping
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CountryEntity, CountryEntity>();

            CreateMap<CountryEntity, CountrySummary>();
        }
    }
}