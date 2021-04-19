using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class GitAccountSourceEntityMapping : EntityMappingConfiguration<GitAccountSourceEntity>
    {
        public override void Configure(EntityTypeBuilder<GitAccountSourceEntity> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}