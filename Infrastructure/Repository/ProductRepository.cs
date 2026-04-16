using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repository;


namespace OrderManagement.Infrastructure.Repository
{
    public class ProductRepository(AppDbContext context) : IBaseRepository<Product>
    {
        private readonly AppDbContext _context = context;

        public async Task<Product> Create(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async void Delete(Product entity)
        {
            await _context.Products.Where(x => x.Id == entity.Id).ExecuteDeleteAsync();

        }

        public async Task<(IEnumerable<Product> Items, int Total)> GetAll(int pageNumber, int pageSize)
        {
            var query = _context.Products.AsNoTracking();
            var total = await _context.Products.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<Product?> GetById(Guid id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}
