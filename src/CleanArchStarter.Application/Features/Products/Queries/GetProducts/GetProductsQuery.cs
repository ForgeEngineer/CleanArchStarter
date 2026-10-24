namespace CleanArchStarter.Application.Features.Products.Queries.GetProducts;

using CleanArchStarter.Application.Common.Messaging;
using CleanArchStarter.Application.Common.Models;

public record GetProductsQuery : IQuery<Result<IReadOnlyList<ProductDto>>>;
