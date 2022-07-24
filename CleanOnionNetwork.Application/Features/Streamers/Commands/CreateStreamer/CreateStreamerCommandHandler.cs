using AutoMapper;
using CleanOnionNetwork.Application.Contracts.Infrastructure;
using CleanOnionNetwork.Application.Contracts.Persistence;
using CleanOnionNetwork.Application.Models;
using CleanOnionNetwork.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanOnionNetwork.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            _unitOfWork.StreamerRepository.AddEntity(streamerEntity);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de streamer");
            }
            _logger.LogInformation($"Streamer {streamerEntity.Id} fue creado existosamente");
            //await SendEmail(streamerEntity);
            return streamerEntity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "rafael116@live.com.mx",
                Body = "Create to new Stremar",
                Subject = "Msj of alert"
            };
            try
            {
                await _emailService.SendEmailAsync(email);
            }
            catch (Exception)
            {
                _logger.LogError($"Error send to email");
            }
        }
    }
}
