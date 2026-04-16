using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Application.UseCases.Product;


namespace OrderManagement.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(CreateProductUseCase createProductUseCase,
        GetProductsUseCase getProductsUseCase, GetProductByIdUseCase getProductByIdUseCase,
        UpdateProductUseCase updateProductUseCase, DeleteProductUseCase deleteProductUseCase) : ControllerBase
    {
        private readonly CreateProductUseCase _createProductUseCase = createProductUseCase;
        private readonly GetProductsUseCase _getProductsUseCase = getProductsUseCase;
        private readonly GetProductByIdUseCase _getProductByIdUseCase = getProductByIdUseCase;
        private readonly UpdateProductUseCase _updateProductUseCase = updateProductUseCase;
        private readonly DeleteProductUseCase _deleteProductUseCase = deleteProductUseCase;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _createProductUseCase.Execute(dto);
            return result != null ? CreatedAtAction(nameof(GetById), result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _getProductsUseCase.Execute(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getProductByIdUseCase.Execute(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDTO dto)
        {
            var success = await _updateProductUseCase.Execute(id, dto);
            return success ? NoContent() : NotFound();


        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _deleteProductUseCase.Execute(id);
            return success ? NoContent() : NotFound();
        }
    }
}
