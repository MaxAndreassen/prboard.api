using System;

namespace foundation.Entities.Contracts
{
    public interface ICrudDates
    {
        DateTime? CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        DateTime? DeletedAt { get; set; }
    }
}