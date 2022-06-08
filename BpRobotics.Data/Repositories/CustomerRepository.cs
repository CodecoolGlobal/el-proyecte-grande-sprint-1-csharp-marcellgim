using BpRobotics.Data.Model;

namespace BpRobotics.Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly IBpRoboticsDataStorage _dataStorage;

        public CustomerRepository(IBpRoboticsDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public List<Customer> GetAll()
        {
            return _dataStorage.Customers;
        }

        public Customer Get(int id)
        {
            return _dataStorage.Customers
                .First(customer => customer.Id == id);
        }

        public void Delete(int id)
        {
            var customer = Get(id);
            _dataStorage.Customers.Remove(customer);
        }

        public void Add(Customer entity)
        {
            _dataStorage.Customers.Add(entity);
        }

        public void Update(int id, Customer entity)
        {
            var customerToUpdate = Get(id);
            customerToUpdate.Id = id;
            customerToUpdate.BillingAddress = entity.BillingAddress;
            customerToUpdate.CompanyName = entity.CompanyName;
            customerToUpdate.ShippingAddress = entity.ShippingAddress;
        }
    }
}
