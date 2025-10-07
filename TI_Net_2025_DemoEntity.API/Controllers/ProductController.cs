using Microsoft.AspNetCore.Mvc;
using TI_Net_2025_DemoEntity.BLL.Services;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.API.Controllers;

[ApiController]
[Route("/api/Product")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetOne(int id)
    {
        return Ok(_productService.GetOne(id));
    }

    [HttpPost]
    public ActionResult Add([FromBody] Product product)
    {
        _productService.Add(product);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] int id, [FromBody] Product product)
    {
        _productService.Update(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _productService.Delete(id);
        return Accepted();
    }
}