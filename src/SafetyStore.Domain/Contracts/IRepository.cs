namespace SafetyStore.Domain.Contracts
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll();
        Task<T?> GetById(int id);
    }
}
