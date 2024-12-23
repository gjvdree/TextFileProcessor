using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TextFileProcessor.Application.Services;
using TextFileProcessor.Application.Services.Interfaces;
using TextFileProcessor.Domain.Extensions;

namespace TextFileProcessor.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) => services
        .AddSingleton<IFileProcessorService, FileProcessorService>()
        .AddMediatR()
        .AddDomainServices();

    private static IServiceCollection AddMediatR(this IServiceCollection services) => services
        .AddMediatR(act => act.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
}