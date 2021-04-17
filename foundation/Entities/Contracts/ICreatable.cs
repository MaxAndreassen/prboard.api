using System;

namespace foundation.Entities.Contracts
{
    public interface ICreatable
    {
        DateTime? CreatedAt { get; set; }
    }
}