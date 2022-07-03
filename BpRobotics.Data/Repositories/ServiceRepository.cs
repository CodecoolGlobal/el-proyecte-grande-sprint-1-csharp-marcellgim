using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data.Repositories;

public class ServiceRepository : IRepository<Service>
{
    private readonly BpRoboticsContext _context;

    public ServiceRepository(BpRoboticsContext context)
    {
        _context = context;
    }
    public async Task<List<Service>> GetAll()
    {
        return await _context.Services
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Service> Get(int id)
    {
        return await _context.Services.SingleAsync(s => s.Id == id);
    }

    public async Task Delete(int id)
    {
        var serviceToDelete = await _context.Services.SingleAsync(s => s.Id == id);
        _context.Remove(serviceToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task Add(Service entity)
    {
        await _context.Services.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public Task<Service> Update(Service entity)
    {
        throw new NotImplementedException();
    }
}