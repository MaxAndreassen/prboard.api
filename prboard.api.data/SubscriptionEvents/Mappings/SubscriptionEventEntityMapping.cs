using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.SubscriptionEvents.Entities;

namespace prboard.api.data.SubscriptionEvents.Mappings
{
    public class SubscriptionEventEntityMapping : EntityMappingConfiguration<SubscriptionEventEntity>
    {
        public override void Configure(EntityTypeBuilder<SubscriptionEventEntity> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany(p => p.SubscriptionEvents)
                .IsRequired();
        }
    }
}