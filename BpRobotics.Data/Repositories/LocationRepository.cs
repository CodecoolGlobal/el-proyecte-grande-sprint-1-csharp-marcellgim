using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly BpRoboticsContext _context;

        public LocationRepository(BpRoboticsContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAll()
        {
            return await _context.Locations.AsNoTracking().ToListAsync();
        }

        public async Task<Location> Get(int id)
        {
            return await _context.Locations.FirstAsync(location => location.Id == id);
        }

        public async Task Delete(int id)
        {
            var location = await Get(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
        }

        public async Task Add(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task<Location> Update(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

            return location;
        }
    }
}
