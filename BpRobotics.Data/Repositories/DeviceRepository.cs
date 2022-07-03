using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Data.Repositories
{
    public class DeviceRepository : IRepository<Device>
    {
        private readonly BpRoboticsContext _context;
        public DeviceRepository(BpRoboticsContext context)
        {
            _context = context;
        }
        public async Task Add(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var device = await Get(id);
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
        }

        public async Task<Device> Get(int id)
        {
            return await _context.Devices
                .SingleAsync(order => order.Id == id);
        }

        public async Task<List<Device>> GetAll()
        {
            return await _context.Devices
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Device> Update(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
            return device;
        }
    }
}
