using System;

namespace foundation.Entities.Contracts
{
    public interface IDeletable
    {
        DateTime? DeletedAt { get; set; }
    }
}