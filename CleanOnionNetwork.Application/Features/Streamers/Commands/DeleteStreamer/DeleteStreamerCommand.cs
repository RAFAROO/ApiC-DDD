using MediatR;

namespace CleanOnionNetwork.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
