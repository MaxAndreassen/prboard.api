using System;
using foundation.Entities.Contracts;

namespace foundation.Entities
{
    public class BaseEntity : ICreatable, IUpdatable, IDeletable, ICrudDates, IUuid, IEntity<int>
    {
        public int Id { get; set; }

        public Guid Uuid { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}