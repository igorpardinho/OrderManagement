using MapsterMapper;
using OrderManagement.Application.DTOs.Pagination;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.UseCases.Product
{
    public class GetProductsUseCase(IUnitOfWork uow, IMapper mapper)
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<ProductResponseDTO>> Execute(int pageNumber, int pageSize)
        {
            var (items, total) = await _uow.Products.GetAll(pageNumber, pageSize);
            var productDtos = _mapper.Map<IEnumerable<ProductResponseDTO>>(items);
            return new PaginatedResult<ProductResponseDTO>(productDtos, total, pageSize);
        }
    }
}
