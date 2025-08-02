using MediatR;
using Microsoft.Extensions.Logging;

namespace SimpleCalculatorCsharp.Src.Application.Pipelines
{
    public class LoggingPipelineBehavior<TRequest, TResponse>(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger = logger;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = next(cancellationToken).GetAwaiter().GetResult();
            _logger.LogInformation($"Handled {typeof(TRequest).Name}");
            return Task.FromResult(response);
        }
    }
}

