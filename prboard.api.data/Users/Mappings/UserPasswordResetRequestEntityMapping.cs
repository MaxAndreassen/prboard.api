using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class UserPasswordResetRequestEntityMapping : EntityMappingConfiguration<UserPasswordResetRequestEntity>
    {
        public override void Configure(EntityTypeBuilder<UserPasswordResetRequestEntity> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithMany();
        }
    }
}