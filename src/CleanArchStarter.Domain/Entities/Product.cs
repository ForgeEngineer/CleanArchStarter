using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchStarter.Domain.Common;

namespace CleanArchStarter.Domain.Entities;

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