using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TextFileProcessor.Domain.Behaviors;
using TextFileProcessor.Domain.Extensions;

namespace TextFileProcessor.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services) => services
            .AddMediatR();

    private static IServiceCollection AddMediatR(this IServiceCollection services) => services
            .AddMediatR(act => act.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
}
