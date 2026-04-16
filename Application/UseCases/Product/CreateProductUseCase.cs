using MapsterMapper;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.UseCases.Product
{
    public class CreateProductUseCase(IUnitOfWork uow, IMapper mapper)
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly IMapper _mapper = mapper;
        public async Task<ProductResponseDTO> Execute(CreateProductDto dto)
        {
            var product = _mapper.Map<ProductEntity>(dto);

            await _uow.Products.Create(product);
            await _uow.CommitAsync();
            return _mapper.Map<ProductResponseDTO>(product);

        }
    }
}
