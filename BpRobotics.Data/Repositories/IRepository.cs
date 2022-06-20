namespace BpRobotics.Data.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task Delete(int id);
    Task Add(T entity);
    Task Update(int id, T entity);

}