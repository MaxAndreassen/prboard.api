using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Countries.Entities;
using prboard.api.domain.Countries.Contracts.Services;

namespace prboard.api.domain.Countries.Services
{
    [DomainService]
    public class CountryListService : ICountryListService
    {
        private readonly IRepository<CountryEntity> _countryRepository;
        private readonly IMapper _mapper;

        public CountryListService(
            IRepository<CountryEntity> countryRepository,
            IMapper mapper
        )
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IList<T>> ListCountriesAsync<T>() where T : class
        {
            var query = _countryRepository.Where(p => p.DeletedAt == null);

            query = query.OrderBy(p => p.Name);

            return await _mapper.ProjectTo<T>(query).ToListAsync();
        }
    }
}