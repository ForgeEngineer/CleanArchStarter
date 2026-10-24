namespace CleanArchStarter.Application.Features.Products.Commands.CreateProduct;

using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Application.Common.Messaging;
using CleanArchStarter.Application.Common.Models;
using CleanArchStarter.Domain.Entities;

public class CreateProductCommandHandler(
    IProductRepository repository,
    IProductPricingService pricingService)
    : ICommandHandler<CreateProductCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var finalPrice = pricingService.ApplyTax(request.Price);
        var product = Product.Create(request.Name, finalPrice);
        await repository.AddAsync(product, cancellationToken);
        return Result<Guid>.Success(product.Id);
    }
}
