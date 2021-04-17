using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class UserVerificationRequestEntityMapping : EntityMappingConfiguration<UserVerificationRequestEntity>
    {
        public override void Configure(EntityTypeBuilder<UserVerificationRequestEntity> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany()
                .IsRequired();
        }
    }
}