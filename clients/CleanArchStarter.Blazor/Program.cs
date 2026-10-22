using CleanArchStarter.Blazor;
using CleanArchStarter.Blazor.Products;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = builder.Configuration["ApiBaseUrl"]
    ?? throw new InvalidOperationException("ApiBaseUrl is not configured in wwwroot/appsettings.json.");

// Register a typed HttpClient whose BaseAddress comes from configuration.
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
builder.Services.AddScoped<ProductsApiClient>();

await builder.Build().RunAsync();
