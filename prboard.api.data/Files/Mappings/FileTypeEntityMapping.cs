using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Files.Entities;

namespace prboard.api.data.Files.Mappings
{
    public class FileTypeEntityMapping : EntityMappingConfiguration<FileTypeEntity>
    {
        public override void Configure(EntityTypeBuilder<FileTypeEntity> builder)
        {
            builder
                .Property(p => p.Type)
                .IsRequired();
        }
    }
}