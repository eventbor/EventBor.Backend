namespace EventBor.Backend.Infrastructure.Database.Repositories;

public interface IRepository<T>
{
    Task<T> InsertAsync(T entity);
    Task<T> SelectByIdAsync(long id);
    IQueryable<T> SelectAll();
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
