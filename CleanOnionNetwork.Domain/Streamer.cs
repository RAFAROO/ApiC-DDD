using CleanOnionNetwork.Domain.Common;

namespace CleanOnionNetwork.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string Nombre { get; set; }  = string.Empty;
        public string Url { get; set; } = string.Empty ;

        public ICollection<Video>? Videos { get; set; }
    }
}
