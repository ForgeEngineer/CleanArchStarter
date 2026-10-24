namespace CleanArchStarter.Infrastructure;

using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigurationMiddleware
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();

        return services;
    }
}
