using OrderManagement.Data;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Domain.Repository;

namespace OrderManagement.Infrastructure.Repository
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private IBaseRepository<ProductEntity>? _productRepository;

        public IBaseRepository<ProductEntity> Products => _productRepository ??= new ProductRepository(_context);

        public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;


        public void Dispose() => _context.Dispose();

    }
}
