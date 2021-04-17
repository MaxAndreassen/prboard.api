using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace foundation.Entities.Mapping
{
    public abstract class EntityMappingConfiguration<T, TKey> : IEntityTypeConfiguration<T>
        where T : class, IEntity<TKey> where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Uuid).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();
        }
    }

    public abstract class EntityMappingConfiguration<T> : EntityMappingConfiguration<T, int> where T : class, IEntity<int>
    {
    }
}