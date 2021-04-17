using System.IO;
using System.Net;

namespace prboard.api.domain.Files.Models
{
    public class FileResponse
    {
        public string Path { get; set; }
        
        public Stream ResponseStream { get; set; }
        
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}