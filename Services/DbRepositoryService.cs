using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services;

public class DbRepositoryService<T>(AppDbContext context) : IRepositoryService<T> where T : class
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(int id, T entity)
    {
        var existing = _dbSet.Find(id);
        if (existing == null) return;

        _context.Entry(existing).CurrentValues.SetValues(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
