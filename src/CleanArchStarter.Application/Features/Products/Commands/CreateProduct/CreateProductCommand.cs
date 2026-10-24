namespace CleanArchStarter.Application.Features.Products.Commands.CreateProduct;

using CleanArchStarter.Application.Common.Messaging;
using CleanArchStarter.Application.Common.Models;

public record CreateProductCommand(string Name, decimal Price) : ICommand<Result<Guid>>;
