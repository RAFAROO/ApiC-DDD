using AutoMapper;
using CleanOnionNetwork.Application.Contracts.Persistence;
using MediatR;

namespace CleanOnionNetwork.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVideosListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.VideoRepository.GetVideoByUsername(request._UserName);
            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
