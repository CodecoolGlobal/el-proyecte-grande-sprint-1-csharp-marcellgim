using BpRobotics.Data.Entity;

namespace BpRobotics.Data.Repositories;

public class OrderRepository : IRepository<Order>
{
    private readonly IBpRoboticsDataStorage _storage;

    public OrderRepository(IBpRoboticsDataStorage storage)
    {
        _storage = storage;
    }

    public List<Order> GetAll() => _storage.Orders.ToList();

    public Order Get(int id) => _storage.Orders.First(user => user.Id == id);

    public void Delete(int id)
    {
        _storage.Orders.Remove(Get(id));
    }

    public void Add(Order entity)
    {
        _storage.Orders.Add(entity);
    }

    public void Update(int id, Order entity)
    {
        var orderToUpdate = Get(id);

        Delete(id);

        if (_storage.Orders.Any(order => order.Id == entity.Id))
        {
            Add(orderToUpdate);
            throw new Exception($"Attempting to update Order ID from {id} to {entity.Id}, but a Order with ID: {entity.Id} already exists!");
        }
        else Add(entity);
    }
}