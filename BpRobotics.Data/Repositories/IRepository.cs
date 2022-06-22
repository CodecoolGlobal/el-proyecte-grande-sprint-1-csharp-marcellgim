namespace BpRobotics.Data.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task Delete(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);

}