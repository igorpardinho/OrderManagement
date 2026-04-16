using MapsterMapper;
using OrderManagement.Application.DTOs.Product;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.UseCases.Product
{
    public class UpdateProductUseCase(IUnitOfWork uow, IMapper mapper)
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> Execute(Guid id, UpdateProductDTO dto)
        {
            var existingProduct = await _uow.Products.GetById(id);
            if (existingProduct == null) return false;
            _mapper.Map(dto, existingProduct);
            _uow.Products.Update(existingProduct);
            return await _uow.CommitAsync();
        }
    }
}
