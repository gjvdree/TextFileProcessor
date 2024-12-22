using MediatR;
using System.Reflection;
using TextFileProcessor.Web.Behaviors;
using TextFileProcessor.Web.Services;
using TextFileProcessor.Web.Services.Interfaces;

namespace TextFileProcessor.Web.Extensions;
internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(act => act.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        return services;
    }

    public static IServiceCollection AddTextFileProcessorServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileProcessorService, FileProcessorService>();

        return services;
    }
}
