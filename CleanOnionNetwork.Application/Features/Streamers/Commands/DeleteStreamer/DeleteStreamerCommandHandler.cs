using AutoMapper;
using CleanOnionNetwork.Application.Contracts.Persistence;
using CleanOnionNetwork.Application.Exceptions;
using CleanOnionNetwork.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanOnionNetwork.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWOrk, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            _unitOfWOrk = unitOfWOrk;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _unitOfWOrk.StreamerRepository.GetByIdAsync(request.Id);
            if (streamerToDelete == null)
            {
                _logger.LogError($"not found the Streamer id {request.Id} in the system");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            _unitOfWOrk.StreamerRepository.DeleteEntity(streamerToDelete);
            await _unitOfWOrk.Complete();
            _logger.LogInformation($"the operation was sucucess, delete {request.Id}");
            return Unit.Value;
        }
    }
}
