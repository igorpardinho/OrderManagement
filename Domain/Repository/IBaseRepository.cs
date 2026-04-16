namespace OrderManagement.Domain.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<(IEnumerable<T> Items, int Total)> GetAll(int pageNumber, int pageSize);
        Task<T?> GetById(Guid id);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
