namespace OrderManagement.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
