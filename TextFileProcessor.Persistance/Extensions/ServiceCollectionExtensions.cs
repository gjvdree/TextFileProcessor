using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TextFileProcessor.Domain.Extensions;
using TextFileProcessor.Persistance.Extensions;

namespace TextFileProcessor.Persistance.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services) => services
            .AddMediatR();

    private static IServiceCollection AddMediatR(this IServiceCollection services) => services
            .AddMediatR(act => act.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
}
