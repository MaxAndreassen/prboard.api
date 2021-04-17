using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prboard.api.domain.Countries.Contracts.Services;
using prboard.api.domain.Countries.Models;

namespace prboard.api.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryListService _countryListService;

        public CountryController(
            ICountryListService countryListService
        )
        {
            _countryListService = countryListService;
        }
        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync()
        {
            var countries = await _countryListService
                .ListCountriesAsync<CountrySummary>();

            return Ok(countries);
        }
    }
}