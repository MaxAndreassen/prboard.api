using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Users.Entities;

namespace prboard.api.data.Users.Mappings
{
    public class UserGitAccountEntityMapping : EntityMappingConfiguration<UserGitAccountEntity>
    {
        public override void Configure(EntityTypeBuilder<UserGitAccountEntity> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany(p => p.GitAccounts);

            builder
                .HasOne(p => p.GitAccountSource)
                .WithMany();
        }
    }
}