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
        public BpRoboticsContext Context { get; set; }

        public PartnerRepository(BpRoboticsContext context)
        {
            Context = context;
        }

        public async Task Add(Partner entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Partner partner = await Get(id);
            if (partner != null)
            {
                Context.Partners.Remove(partner);
                await Context.SaveChangesAsync();
            }
            
        }

        public async Task<Partner> Get(int id)
        {
            return await Context.Partners
                .AsNoTracking()
                .FirstAsync(partner => partner.Id == id);
        }

        public async Task<List<Partner>> GetAll()
        {
            return await Context.Partners
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
