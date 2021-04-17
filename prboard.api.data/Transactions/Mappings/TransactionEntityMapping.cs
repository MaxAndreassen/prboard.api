using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Transactions.Entities;

namespace prboard.api.data.Transactions.Mappings
{
    public class TransactionEntityMapping : EntityMappingConfiguration<TransactionEntity>
    {
        public override void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder
                .HasOne(e => e.PurchasingUser)
                .WithMany()
                .IsRequired();

            builder
                .Property(p => p.AmountInPence)
                .IsRequired();
        }
    }
}