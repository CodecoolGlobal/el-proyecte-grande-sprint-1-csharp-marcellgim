using BpRobotics.Data.Entity;

namespace BpRobotics.Data.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly IBpRoboticsDataStorage _storage;

    public ProductRepository(IBpRoboticsDataStorage storage)
    {
        _storage = storage;
    }

    public List<Product> GetAll() => _storage.Products.ToList();

    public Product Get(int id) => _storage.Products.First(user => user.Id == id);

    public void Delete(int id)
    {
        _storage.Products.Remove(Get(id));
    }

    public void Add(Product entity)
    {
        entity.Id = (_storage.Products.LastOrDefault()?.Id ?? 0) + 1;
        _storage.Products.Add(entity);
    }

    public void Update(int id, Product entity)
    {
        // TODO override properties
        var userToUpdate = Get(id);
    }
}