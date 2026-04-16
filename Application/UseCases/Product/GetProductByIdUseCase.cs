using MapsterMapper;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.UseCases.Product
{
    public class GetProductByIdUseCase(IUnitOfWork uow, IMapper mapper)
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly IMapper _mapper = mapper;
        public async Task<ProductResponseDTO> Execute(Guid id)
        {
            var product = await _uow.Products.GetById(id) ?? throw new Exception("Product not found");
            return _mapper.Map<ProductResponseDTO>(product);
        }
    }


}
