using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly BpRoboticsContext _context;

        public CustomerRepository(BpRoboticsContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FirstAsync(customer => customer.Id == id);
        }

        public async Task Delete(int id)
        {
            var customer = await Get(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Add(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

    }
}
