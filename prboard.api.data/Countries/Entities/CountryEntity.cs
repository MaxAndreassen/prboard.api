using foundation.Entities;

namespace prboard.api.data.Countries.Entities
{
    public class CountryEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public string Alpha2 { get; set; }
        
        public string Alpha3 { get; set; }
    }
}