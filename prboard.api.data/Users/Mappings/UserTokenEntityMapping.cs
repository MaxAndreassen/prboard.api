using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class UserTokenEntityMapping : EntityMappingConfiguration<UserTokenEntity>
    {
        public override void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithMany();
        }
    }
}