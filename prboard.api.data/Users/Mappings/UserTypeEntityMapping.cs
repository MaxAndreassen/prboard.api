using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class UserTypeEntityMapping : EntityMappingConfiguration<UserTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<UserTypeEntity> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}