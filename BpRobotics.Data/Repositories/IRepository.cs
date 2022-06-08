namespace BpRobotics.Data.Repositories;

public interface IRepository<T>
{
    List<T> GetAll();
    T Get(int id);
    void Delete(int id);
    void Add(T entity);
    void Update(int id, T entity);

}