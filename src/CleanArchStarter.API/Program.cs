using CleanArchStarter.API.Infrastructure;
using CleanArchStarter.Application;
using CleanArchStarter.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddCors(options =>
    options.AddPolicy("AllowFrontends", policy =>
        policy.WithOrigins(
                "http://localhost:4200",  "https://localhost:4200",
                "http://localhost:5173",  "https://localhost:5173",
                "http://localhost:5000",  "https://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.Services.SeedProductsAsync();
}

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowFrontends");
}
app.UseExceptionHandler();
app.MapControllers();

app.Run();

// Exposed so CleanArchStarter.API.Tests can host the app with WebApplicationFactory.
public partial class Program;
