using MediatR;

namespace CleanOnionNetwork.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string _UserName { get; set; } = string.Empty;
        public GetVideosListQuery(string username)
        {
            _UserName = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
