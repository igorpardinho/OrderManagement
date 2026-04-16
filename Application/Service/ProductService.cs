

using MapsterMapper;
using OrderManagement.Application.DTOs.Pagination;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;


namespace OrderManagement.Application.Service
{
    public class ProductService(IUnitOfWork uow, IMapper mapper)
    {

        private readonly IUnitOfWork _uow = uow;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDTO> Create(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var createdProduct = await _uow.Products.Create(product);
            await _uow.CommitAsync();
            return _mapper.Map<ProductDTO>(createdProduct);
        }

        public async Task<PaginatedResult<ProductDTO>> GetAll(int pageNumber, int pageSize)
        {
            var (items, total) = await _uow.Products.GetAll(pageNumber, pageSize);
            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(items);
            return new PaginatedResult<ProductDTO>(productDtos, total, pageSize);
        }

        public async Task<ProductDTO?> GetById(Guid id)
        {
            var product = await _uow.Products.GetById(id);
            return product == null ? null : _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> Update(Guid id, UpdateProductDTO dto)
        {
            var existingProduct = await _uow.Products.GetById(id);
            if (existingProduct == null) return false;
            _mapper.Map(dto, existingProduct);
            _uow.Products.Update(existingProduct);
            return await _uow.CommitAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var existingProduct = await _uow.Products.GetById(id);
            if (existingProduct == null) return false;
            _uow.Products.Delete(existingProduct);
            return await _uow.CommitAsync();
        }
    }
}
