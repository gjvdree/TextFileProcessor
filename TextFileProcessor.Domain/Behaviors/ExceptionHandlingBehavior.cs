using MediatR;
using Microsoft.Extensions.Logging;

namespace TextFileProcessor.Domain.Behaviors;

internal class ExceptionHandlingBehavior<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation($"Handling {typeof(TRequest).Name}");
            TResponse? res = await next();
            logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return res;
        }
        catch (Exception ex)
        {
            // Log and handle the exception
            logger.LogError(ex, "Unexpected error occured while handling a request");
            throw;
        }
    }
}
