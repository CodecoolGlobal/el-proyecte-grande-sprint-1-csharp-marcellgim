using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace BpRobotics.Data.Repositories
{
    
    public class PartnerRepository : IRepository<Partner>
    {
        private readonly BpRoboticsContext _context;

        public PartnerRepository(BpRoboticsContext context)
        {
            _context = context;
        }

        public async Task Add(Partner entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var partner = await Get(id);

            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
        }

        public async Task<Partner> Get(int id)
        {
            return await _context.Partners
                .SingleAsync(partner => partner.Id == id);
        }

        public async Task<List<Partner>> GetAll()
        {
            return await _context.Partners
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Partner> Update(Partner entity)
        {
            var partnerToUpdate = await Get(entity.Id);
            partnerToUpdate.PhoneNumber = entity.PhoneNumber;
            partnerToUpdate.CompanyName = entity.CompanyName;
            return partnerToUpdate;
        }
    }
}
