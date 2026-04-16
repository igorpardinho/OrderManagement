using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repository;

namespace OrderManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ProductEntity> Products { get; }
        Task<bool> CommitAsync();


    }
}
