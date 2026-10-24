namespace CleanArchStarter.API.Tests.Products;

using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

public class GetProductsEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public GetProductsEndpointTests(WebApplicationFactory<Program> factory)
        => _factory = factory.WithWebHostBuilder(builder => builder.UseEnvironment("Development"));

    [Fact]
    public async Task GetProducts_ReturnsOkWithSeededProducts()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/products");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var products = await response.Content.ReadFromJsonAsync<List<ProductResponse>>();
        Assert.NotNull(products);
        Assert.NotEmpty(products);
    }

    private sealed record ProductResponse(Guid Id, string Name, decimal Price);
}
