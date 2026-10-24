namespace CleanArchStarter.Application.Common.Interfaces;

using CleanArchStarter.Domain.Entities;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
