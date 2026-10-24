namespace CleanArchStarter.Application;

using System.Reflection;
using CleanArchStarter.Application.Common.Behaviors;
using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigurationMiddleware
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient<IProductPricingService, ProductPricingService>();

        return services;
    }
}
