using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Countries.Entities;

namespace prboard.api.data.Countries.Mappings
{
    public class CountryEntityMapping : EntityMappingConfiguration<CountryEntity>
    {
        public override void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}