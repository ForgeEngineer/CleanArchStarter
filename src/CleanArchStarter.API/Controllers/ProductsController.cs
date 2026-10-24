namespace CleanArchStarter.API.Controllers;

using CleanArchStarter.Application.Features.Products.Commands.CreateProduct;
using CleanArchStarter.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetProductsQuery(), cancellationToken);
        return result.Succeeded ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.Succeeded
            ? CreatedAtAction(nameof(GetAll), new { id = result.Value }, result.Value)
            : BadRequest(result.Error);
    }
}
