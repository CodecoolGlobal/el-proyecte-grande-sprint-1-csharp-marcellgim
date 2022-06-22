using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model;
using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Location> _locationRepository;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Location> locationRepository)
        {
            _customerRepository = customerRepository;
            _locationRepository = locationRepository;
        }

        public async Task<List<CustomerDTO>> ListCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.ToCustomerView();
        }

        public async Task<CustomerDetailedDTO> GetById(int customerId)
        {
            var customer = await _customerRepository.Get(customerId);
            return customer.ToCustomerDetailedView();
        }

        public async Task NewCustomer(CustomerDetailedDTO newCustomerDto)
        {
            await _customerRepository.Add(newCustomerDto.ToCustomerEntity());
        }

        public async Task<CustomerDetailedDTO> UpdateUser(CustomerUpdateDTO updatedCustomerDto)
        {
            var customerModel = await CreateCustomerModelById(updatedCustomerDto);

            await _customerRepository.Update(customerModel.ToCustomerEntity());

            return customerModel.ToCustomerDetailedView();
        }

        public async Task DeleteById(int customerId) => await _customerRepository.Delete(customerId);

        private async Task<CustomerModel> CreateCustomerModelById(CustomerUpdateDTO updatedCustomerDto)
        {
            var customerId = updatedCustomerDto.Id;
            var billingLocationId = updatedCustomerDto.BillingLocationId;
            var shippingLocationId = updatedCustomerDto.ShippingLocationId;

            var billingLocation = await _locationRepository.Get(billingLocationId);
            var shippingLocation = await _locationRepository.Get(shippingLocationId);
            var customerModel = updatedCustomerDto.ToCustomerModel();

            customerModel.ShippingAddress = shippingLocation;
            customerModel.BillingAddress = billingLocation;

            var customerEntity = await _customerRepository.Get(customerId);
            customerModel.User = customerEntity.User;

            return customerModel;
        }
    }
}
