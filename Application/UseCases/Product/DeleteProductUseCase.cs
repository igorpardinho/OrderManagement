using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.UseCases.Product
{
    public class DeleteProductUseCase(IUnitOfWork uow)
    {
        private readonly IUnitOfWork _uow = uow;
        public async Task<bool> Execute(Guid id)
        {
            var existingProduct = await _uow.Products.GetById(id);
            if (existingProduct == null) return false;
            _uow.Products.Delete(existingProduct);
            return await _uow.CommitAsync();
        }
    }
}
