namespace CleanArchStarter.Blazor.Products;

using System.Net.Http.Json;
using System.Text.Json;
using CleanArchStarter.Blazor.Models;

public class ProductsApiClient(HttpClient http)
{
    private static readonly JsonSerializerOptions JsonOptions =
        new() { PropertyNameCaseInsensitive = true };

    public Task<Product[]?> GetProductsAsync(CancellationToken ct = default) =>
        http.GetFromJsonAsync<Product[]>("api/products", JsonOptions, ct);
}
