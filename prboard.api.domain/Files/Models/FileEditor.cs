using System;
using Microsoft.AspNetCore.Http;

namespace prboard.api.domain.Files.Models
{
    public class FileEditor
    {
        public Guid? Uuid { get; set; }
        
        public IFormFile File { get; set; }
    }
}