namespace EventBor.Backend.Infrastructure.Database.Repositories;

internal class Repository<T> : IRepository<T>
    where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T> InsertAsync(T entity)
    {
        _context.Add(entity);
        
        await _context.SaveChangesAsync();

        return entity;
    }

    public IQueryable<T> SelectAll() => _context.Set<T>();

    public async Task<T> SelectByIdAsync(long id) =>
        await _context.Set<T>().FindAsync(id);

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}
