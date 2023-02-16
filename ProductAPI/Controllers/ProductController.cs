using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly ProductService _productService;

    public ProductController(ILogger<ProductController> logger,ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return  _productService.Products;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Product>> Get(Guid productID)
    {
        var product = await _productService.Read(productID);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product newProduct)
    {
        await _productService.Create(newProduct);

        return CreatedAtAction(nameof(Get), new { id = newProduct.SKU }, newProduct);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid productId, Product updatedProduct)
    {
        var product = await _productService.Read(productId);

        if (product is null)
        {
            return NotFound();
        }

        await _productService.Update(productId, product);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid productID)
    {
        var product = await _productService.Read(productID);

        if (product is null)
        {
            return NotFound();
        }

        await _productService.Delete(productID);

        return NoContent();
    }
}
