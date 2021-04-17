using System;

namespace prboard.api.domain.Countries.Models
{
    public class CountrySummary
    {
        public Guid Uuid { get; set; }
        
        public string Name { get; set; }
        
        public string Alpha2 { get; set; }
        
        public string Alpha3 { get; set; }
    }
}