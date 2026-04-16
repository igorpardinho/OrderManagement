using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Application.Service;

namespace OrderManagement.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ProductService productService) : ControllerBase
    {
        private readonly ProductService _productService = productService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _productService.Create(dto);
            return result != null ? CreatedAtAction(nameof(GetById), result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAll(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productService.GetById(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDTO dto)
        {
            var success = await _productService.Update(id, dto);
            return success ? NoContent() : NotFound();


        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _productService.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}
