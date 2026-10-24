namespace CleanArchStarter.Application.Common.Interfaces;

public interface IProductPricingService
{
    decimal ApplyTax(decimal price);
}
