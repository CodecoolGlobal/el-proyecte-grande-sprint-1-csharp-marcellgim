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
            .Include(s => s.Partner)
            .Include(s=>s.Device)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Service> Get(int id)
    {
        return await _context.Services
            .Include(s => s.Partner)
            .Include(s => s.Device)
                .ThenInclude(d=>d.Product)
            .SingleAsync(s => s.Id == id);
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

    public async Task<Service> Update(Service entity)
    {
        _context.Services.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}