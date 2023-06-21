using CleanArquitecture.Domain.Common;

namespace CleanArquitecture.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Nombre { get; set; }
        public string? Url { get; set; }
        public List<Video>? Videos { get; set; }
    }
}
