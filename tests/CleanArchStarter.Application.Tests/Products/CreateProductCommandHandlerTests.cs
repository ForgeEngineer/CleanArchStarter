namespace CleanArchStarter.Application.Tests.Products;

using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Application.Features.Products.Commands.CreateProduct;
using CleanArchStarter.Domain.Entities;

public class CreateProductCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_ReturnsSuccessAndStoresProduct()
    {
        var repository = new FakeProductRepository();
        var pricingService = new FakeProductPricingService();
        var handler = new CreateProductCommandHandler(repository, pricingService);
        var command = new CreateProductCommand("Widget", 10.00m);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.Succeeded);
        Assert.NotEqual(Guid.Empty, result.Value);
        var stored = await repository.GetAllAsync();
        Assert.Single(stored);
        Assert.Equal("Widget", stored[0].Name);
    }

    [Fact]
    public async Task Handle_ValidCommand_AppliesPricingService()
    {
        var repository = new FakeProductRepository();
        var pricingService = new FakeProductPricingService();
        var handler = new CreateProductCommandHandler(repository, pricingService);
        var command = new CreateProductCommand("Widget", 10.00m);

        await handler.Handle(command, CancellationToken.None);

        var stored = await repository.GetAllAsync();
        // FakeProductPricingService doubles the price; verify the stored price reflects it
        Assert.Equal(20.00m, stored[0].Price);
    }

    private sealed class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = [];

        public Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<Product>>(_products.AsReadOnly());
    }

    private sealed class FakeProductPricingService : IProductPricingService
    {
        public decimal ApplyTax(decimal price) => price * 2;
    }
}
