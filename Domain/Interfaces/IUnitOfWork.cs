using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repository;

namespace OrderManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Product> Products { get; }
        Task<bool> CommitAsync();


    }
}
