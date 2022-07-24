using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanOnionNetwork.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<IRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<IRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception exception)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(exception, "Application Request, Exception for request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
