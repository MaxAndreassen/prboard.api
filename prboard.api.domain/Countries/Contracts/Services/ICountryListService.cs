using System.Collections.Generic;
using System.Threading.Tasks;

namespace prboard.api.domain.Countries.Contracts.Services
{
    public interface ICountryListService
    {
        Task<IList<T>> ListCountriesAsync<T>() where T : class;
    }
}