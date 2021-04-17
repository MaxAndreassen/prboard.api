using System;

namespace foundation.Entities.Contracts
{
    public interface IUpdatable
    {
        DateTime? UpdatedAt { get; set; }
    }
}