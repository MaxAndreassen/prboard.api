using System.Collections.Generic;

namespace foundation.Models
{
    public class PaginatedList<T>
    {
        public IList<T> Items { get; set; }
        
        public int? CurrentPage { get; set; }
        
        public int TotalItems { get; set; }
    }
}