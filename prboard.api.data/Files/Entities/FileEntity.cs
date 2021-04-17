using foundation.Entities;

namespace prboard.api.data.Files.Entities
{
    public class FileEntity : BaseEntity
    {
        public virtual FileTypeEntity FileType { get; set; }

        public string Url { get; set; }
        
        public string Extension { get; set; }
        
        public string FileName { get; set; }
        
        public string FileContents { get; set; }
        
        public long FileSize { get; set; }
    }
}