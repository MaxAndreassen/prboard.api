using foundation.Entities;
using prboard.api.data.Files.Enums;

namespace prboard.api.data.Files.Entities
{
    public class FileTypeEntity : BaseEntity
    {
        public FileType Type { get; set; }
        
        public string SystemName { get; set; }
    }
}