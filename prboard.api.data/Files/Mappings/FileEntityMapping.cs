using foundation.Entities.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prboard.api.data.Files.Entities;

namespace prboard.api.data.Files.Mappings
{
    public class FileEntityMapping : EntityMappingConfiguration<FileEntity>
    {
        public override void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder
                .Property(p => p.Url)
                .IsRequired();

            builder
                .HasOne(p => p.FileType)
                .WithMany();
        }
    }
}