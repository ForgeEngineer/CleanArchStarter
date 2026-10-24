namespace CleanArchStarter.Infrastructure.Persistence;

using System.Collections.Concurrent;
using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Domain.Entities;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<Guid, Product> _store = new();

    public Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        _store[product.Id] = product;
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Product> list = _store.Values.ToList();
        return Task.FromResult(list);
    }
}
