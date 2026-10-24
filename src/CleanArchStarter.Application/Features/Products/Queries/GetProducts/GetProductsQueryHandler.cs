namespace CleanArchStarter.Application.Features.Products.Queries.GetProducts;

using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Application.Common.Messaging;
using CleanArchStarter.Application.Common.Models;

public class GetProductsQueryHandler(IProductRepository repository)
    : IQueryHandler<GetProductsQuery, Result<IReadOnlyList<ProductDto>>>
{
    public async Task<Result<IReadOnlyList<ProductDto>>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await repository.GetAllAsync(cancellationToken);

        var dtos = products
            .Select(p => new ProductDto(p.Id, p.Name, p.Price))
            .ToList();

        return Result<IReadOnlyList<ProductDto>>.Success(dtos);
    }
}
