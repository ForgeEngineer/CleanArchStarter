namespace CleanArchStarter.API.Infrastructure;

using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Domain.Entities;

public static class SeedData
{
    public static async Task SeedProductsAsync(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        var repository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

        var existing = await repository.GetAllAsync();
        if (existing.Count > 0)
            return;

        var products = new[]
        {
            Product.Create("Mechanical Keyboard", 129.99m),
            Product.Create("27\" 4K Monitor",     379.00m),
            Product.Create("USB-C Docking Station", 89.50m),
            Product.Create("Ergonomic Mouse",     59.99m),
        };

        foreach (var product in products)
            await repository.AddAsync(product);
    }
}
