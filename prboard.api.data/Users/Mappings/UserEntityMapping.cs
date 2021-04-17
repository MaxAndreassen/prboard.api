using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class UserEntityMapping : EntityMappingConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasOne(p => p.Country)
                .WithMany();

            builder
                .HasOne(p => p.UserType)
                .WithMany();
        }
    }
}