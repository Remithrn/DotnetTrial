using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Entities.Products.Interface;
using Product_Entities.Products.Payload;

namespace Products_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductPayload payload)
        {
            var product = await _productService.CreateAsync(payload);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ProductPayload payload)
        {
            var updatedProduct = await _productService.UpdateAsync(id, payload);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
