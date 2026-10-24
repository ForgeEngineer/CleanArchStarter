namespace CleanArchStarter.Domain.Entities;

using CleanArchStarter.Domain.Common;

public sealed class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    private Product() { }

    private Product(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public static Product Create(string name, decimal price)
        => new(Guid.NewGuid(), name, price);
}
