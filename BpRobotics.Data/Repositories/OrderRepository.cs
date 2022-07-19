using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data.Repositories;

public class OrderRepository : IRepository<Order>
{
    private readonly BpRoboticsContext _context;

    public OrderRepository(BpRoboticsContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAll()
    {
        return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Devices)
                .ThenInclude(d => d.Product)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order> Get(int id)
    {
        return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Devices)
                .ThenInclude(d => d.Product)
            .AsNoTracking()
            .SingleAsync(order => order.Id == id);
    }

    public async Task Delete(int id)
    {
        var order = await _context.Orders.SingleAsync(o => o.Id == id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task Add(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order> Update(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }
}