

using OrderManagement.Data;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Domain.Repository;
using OrderManagement.Infrastructure.Repository;

namespace OrderManagement.Infrastructure
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private IBaseRepository<Product>? _productRepository;

        public IBaseRepository<Product> Products => _productRepository ??= new ProductRepository(_context);

        public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;


        public void Dispose() => _context.Dispose();

    }
}
