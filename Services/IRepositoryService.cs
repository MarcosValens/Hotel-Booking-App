namespace HotelApp.Services;

public interface IRepositoryService<T>
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Add(T entity);
    void Update(int id, T entity);
    void Delete(int id);
}
