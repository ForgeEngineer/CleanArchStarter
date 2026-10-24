namespace CleanArchStarter.Application.Services;

using CleanArchStarter.Application.Common.Interfaces;

public class ProductPricingService : IProductPricingService
{
    private const decimal TaxRate = 0.10m;

    public decimal ApplyTax(decimal price) => Math.Round(price * (1 + TaxRate), 2);
}
