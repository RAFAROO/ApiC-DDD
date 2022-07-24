using AutoMapper;
using CleanOnionNetwork.Application.Contracts.Persistence;
using CleanOnionNetwork.Application.Exceptions;
using CleanOnionNetwork.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanOnionNetwork.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            //var streamerToUpdate = await _streamerRepository.GetByIdAsync(request.Id);
            var streamerToUpdate = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);
            if(streamerToUpdate == null)
            {
                _logger.LogError($"not found the Streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));
            _unitOfWork.StreamerRepository.UpdateEntity(streamerToUpdate);
            await _unitOfWork.Complete();
            _logger.LogInformation($"the operation was sucucess, update {request.Id}");
            return Unit.Value;
        }
    }
}
